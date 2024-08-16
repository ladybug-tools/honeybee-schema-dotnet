

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

public static class HttpHelper
{
    private static HttpClient _httpClient
    {
        get
        {
            var _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent", "Anything");
            return _client;
        }
    }

    private static HttpClient _httpClientPollination
    {
        get
        {
            var _clientPollination = new HttpClient();
            _clientPollination.DefaultRequestHeaders.Add("User-Agent", "Anything");
            var token = Environment.GetEnvironmentVariable("PollinationApiKey");
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("Failed to get PollinationApiKey from the environment variable!");

            _clientPollination.DefaultRequestHeaders.Add("Authorization", $"token {token}");
            return _clientPollination;

        }
    }

    public static void SetUp()
    {
        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
    }

    public static string DownloadFile(string uri, string outputPath)
    {
        return DownloadFileAsync(_httpClient, uri, outputPath).GetAwaiter().GetResult();
    }
    private static async Task<string> DownloadFileAsync(HttpClient client, string uri, string outputPath)
    {
        Uri uriResult;

        if (!Uri.TryCreate(uri, UriKind.Absolute, out uriResult))
            throw new InvalidOperationException($"URI is invalid. {uri}");

        client.DefaultRequestHeaders.Add("Accept", "application/octet-stream");
        var response = await client.GetAsync(uriResult);
        Console.WriteLine($"Downloading {uri}");
        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            var fileInfo = new FileInfo(outputPath);
            using (var fileStream = fileInfo.OpenWrite())
            {
                await stream.CopyToAsync(fileStream);
            }

            if (!fileInfo.Exists)
                throw new FileNotFoundException("Failed to download file.", nameof(outputPath));

            Console.WriteLine($"Saved to {outputPath}");
            return outputPath;
        }
    }

    public static List<string> DownloadPollinationAssets(string targetDir, string apiUrl, string fileExtension = default)
    {
        return DownloadGithubAssets(_httpClientPollination, targetDir, apiUrl, fileExtension);
    }

    public static List<string> DownloadGithubAssets(string targetDir, string apiUrl, string fileExtension = default)
    {
        return DownloadGithubAssets(_httpClient, targetDir, apiUrl, fileExtension);
    }

    private static List<string> DownloadGithubAssets(HttpClient client, string targetDir, string apiUrl, string fileExtension = default)
    {
        var json = client.GetStringAsync(apiUrl).GetAwaiter().GetResult();
        var obj = System.Text.Json.JsonSerializer.Deserialize<GithubRelease>(json);
        var allAssets = obj.assets;

        var assets = fileExtension == default ? allAssets?.Take(1) : allAssets?.Where(_ => (_?.name?.EndsWith(fileExtension)).GetValueOrDefault());

        if (assets == null || assets.Count() == 0)
            throw new ArgumentException($"Failed to find any valid installer asset from {apiUrl}");


        // download all
        var downloadedFiles = new List<string>();
        Directory.CreateDirectory(targetDir);
        foreach (var asset in assets)
        {
            var assetName = asset?.name;
            var assetUrl = asset?.url; //"https://api.github.com/repos/pollination/ladybug-tools-installer/releases/assets/61786549";

            var saveAs = System.IO.Path.Combine(targetDir, assetName);
            Console.WriteLine($"Downloading {assetName} from {assetUrl} to {saveAs}");
            var filePath = HttpHelper.DownloadFileAsync(client, assetUrl, saveAs).GetAwaiter().GetResult();

            if (File.Exists(filePath))
            {
                Console.WriteLine($"Downloaded {assetName} to {filePath}");
                downloadedFiles.Add(filePath);
            }
            else
                throw new ArgumentException($"Failed to download {assetName}");

        }

        return downloadedFiles;
    }



    class GithubRelease
    {
        public string zipball_url { get; set; }
        public List<GithubReleaseAsset> assets { get; set; }
    }

    class GithubReleaseAsset
    {
        public string url { get; set; }
        public string name { get; set; }
        //public string browser_download_url { get; set; }
    }

}

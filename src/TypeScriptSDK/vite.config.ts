import { defineConfig, UserConfig } from 'vite';
import tsconfigPaths from 'vite-tsconfig-paths';

export default defineConfig({
  plugins: [tsconfigPaths()],
  build: {
    lib: {
      entry: './index.ts',
      name: 'schema',
      fileName: (format) => `index.${format}.js`
    },
    
  }
} satisfies UserConfig);
import { plainToInstance } from "class-transformer";
import "reflect-metadata";
export function deepTransform<T extends object>(cls: new () => T, plain: any): T {
    // Use a try-catch block for abstract classes
    let instance: T;
    try {
        instance = plainToInstance(cls, plain, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
    } catch (e) {
        // If cls is abstract, create a plain object with the same properties
        instance = plain as T;
    }

    for (const key of Object.keys(instance)) {
        const value = (instance as any)[key];

        // If the value is a plain object and the class has a type hint
        const metadataType = Reflect.getMetadata('design:type', instance, key);

        if (
            value &&
            typeof value === 'object' &&
            metadataType &&
            typeof metadataType === 'function' &&
            metadataType !== Object &&
            !(value instanceof metadataType)
        ) {
            (instance as any)[key] = deepTransform(metadataType, value);
        }
    }

    return instance;
}
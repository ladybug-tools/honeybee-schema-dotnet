import { registerDecorator, ValidationOptions, ValidationArguments } from 'class-validator';


// Custom decorator to validate nested arrays of numbers
export function IsNestedNumberArray(validationOptions?: ValidationOptions) {
    return function (object: Object, propertyName: string) {
        registerDecorator({
            name: 'isNestedNumberArray',
            target: object.constructor,
            propertyName: propertyName,
            options: validationOptions,
            validator: {
                validate(value: any, args: ValidationArguments) {
                    if (value === undefined || value === null) return true; // Allow optional values
                    if (!Array.isArray(value)) return false;
                    return value.every(
                        (arr: any) => Array.isArray(arr) && arr.every(
                            (subArr: any) => 
                              (Array.isArray(subArr) && subArr.every(
                                (num: any) => typeof num === 'number'
                              )) || 
                              typeof subArr === 'number'
                        )
                    );
                },
                defaultMessage(args: ValidationArguments) {
                    return `${args.property} must be number[][] or number[][][]`;
                }
            }
        });
    };
}
  
  
// Custom decorator to validate nested arrays of numbers
export function IsNestedIntegerArray(validationOptions?: ValidationOptions) {
    return function (object: Object, propertyName: string) {
        registerDecorator({
            name: 'isNestedIntegerArray',
            target: object.constructor,
            propertyName: propertyName,
            options: validationOptions,
            validator: {
                validate(value: any, args: ValidationArguments) {
                    if (value === undefined || value === null) return true; // Allow optional values
                    if (!Array.isArray(value)) return false;
                    return value.every(
                        (arr: any) => Array.isArray(arr) && arr.every(
                            (subArr: any) => 
                              (Array.isArray(subArr) && subArr.every(
                                (num: any) => Number.isInteger(num)
                              )) || 
                              Number.isInteger(subArr)
                        )
                    );
                },
                defaultMessage(args: ValidationArguments) {
                    return `${args.property} must be number[][] or number[][][]`;
                }
            }
        });
    };
}


// Custom decorator to validate nested arrays of numbers
export function IsNestedStringArray(validationOptions?: ValidationOptions) {
    return function (object: Object, propertyName: string) {
        registerDecorator({
            name: 'isNestedStringArray',
            target: object.constructor,
            propertyName: propertyName,
            options: validationOptions,
            validator: {
                validate(value: any, args: ValidationArguments) {
                    if (value === undefined || value === null) return true; // Allow optional values
                    if (!Array.isArray(value)) return false;
                    return value.every(
                        (arr: any) => Array.isArray(arr) && arr.every(
                            (subArr: any) => 
                              (Array.isArray(subArr) && subArr.every(
                                (num: any) => typeof num === 'string'
                              )) || 
                              typeof subArr === 'string'
                        )
                    );
                },
                defaultMessage(args: ValidationArguments) {
                    return `${args.property} must be string[][] or string[][][]`;
                }
            }
        });
    };
}
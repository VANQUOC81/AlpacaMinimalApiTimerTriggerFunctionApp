# TimerTrigger - C<span>#</span>

The `TimerTrigger` makes it incredibly easy to have your functions executed on a schedule. This sample demonstrates a simple use case of calling your function every 5 minutes.

## How it works

For a `TimerTrigger` to work, you provide a schedule in the form of a [cron expression](https://en.wikipedia.org/wiki/Cron#CRON_expression)(See the link for full details). A cron expression is a string with 6 separate expressions which represent a given schedule via patterns. The pattern we use to represent every 5 minutes is `0 */5 * * * *`. This, in plain text, means: "When seconds is equal to 0, minutes is divisible by 5, for any hour, day of the month, month, day of the week, or year".

## Learn more

<TODO> Documentation

## Notes ##

You need to have the MS Azure Storage Emulator installed and running to run the TimerTrigger locally. Otherwise it won't work.
<PackageReference Include="Microsoft.Azure.Functions.Worker.Sdk" Version="1.11.0" /> is the minimal SDK version that runs on .NET 8.
Looks like when creating new project via 'Azure Functions :  Create New Project' in VS Code using the Timing Trigger template creates below issue:
https://github.com/Azure/azure-functions-core-tools/issues/2640

That is because it automatically gets upgraded to newest version when you create new project:

<PackageReference Include="Microsoft.Azure.Functions.Worker" Version="2.0.0" />

Because in this package version 1.24.0 and above you get parameter argument value cannot be null when running your function app. Don't know what I need to adjust though.

I upgraded all packages to newest version except above ones and it is still working with this current file structure which was taken from AzureFunctionHelloWorld project.
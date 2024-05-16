using Newtonsoft.Json;
using PPMDotNetCore.ConsoleAppRefitExample;
using Refit;
using System;

try
{
	RefitExample refitExample = new RefitExample();
	await refitExample.RunAsync();
}
catch (Exception ex)
{

	Console.WriteLine(ex.ToString());
}
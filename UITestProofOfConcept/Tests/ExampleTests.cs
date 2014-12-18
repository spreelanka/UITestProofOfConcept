
using System;
using NUnit.Framework;
using Xamarin.UITest;
using System.Text.RegularExpressions;
using System.Linq;

namespace Tests
{
	[TestFixture]
	public class ExampleTests
	{
		IApp _app;

		public string PathToIPA { get; private set; }

		[TestFixtureSetUp]
		public void TestFixtureSetup ()
		{
			const string TargetAppName = "UITestProofOfConcept";
			var pwd = System.IO.Directory.GetCurrentDirectory ();
			var match = Regex.Match (pwd, @"^(.*)/([^\/]*)/[^\/]*.app$");
			var applicationDir = match.Groups [1];
			var apps = System.IO.Directory.GetDirectories (applicationDir.Value);
			var targetAppDirectory = apps.FirstOrDefault (a => System.IO.Directory.Exists (string.Format ("{0}/{1}.app", a, TargetAppName)));

			if (System.IO.Directory.Exists (targetAppDirectory))
				PathToIPA = string.Format ("{0}/{1}.app", targetAppDirectory, TargetAppName);
			else
				throw new Exception ("target app name incorrect or target app not built");
		}

		void ConfigureTest ()
		{
			var configurator = ConfigureApp.iOS
				.AppBundle (PathToIPA);

			configurator.Debug ();

			_app = configurator.StartApp ();
		}

		[Test]
		public void FirstTest ()
		{

			ConfigureTest ();
			_app.Repl ();

			Assert.True (true);
		}



	}
}

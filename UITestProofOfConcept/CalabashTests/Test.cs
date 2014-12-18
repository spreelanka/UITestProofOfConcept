using NUnit.Framework;
using System;
using Xamarin.UITest;
using System.Text.RegularExpressions;
using System.Linq;

namespace CalabashTests
{
	[TestFixture ()]
	public class Test
	{
		IApp _app;

		public string PathToIPA { get; private set; }

		[SetUp]
		public void TestFixtureSetup ()
		{
			const string TargetAppName = "UITestProofOfConcept";
			PathToIPA = string.Format ("../../../UITestProofOfConcept/bin/iPhoneSimulator/Debug/{0}.app", TargetAppName);
		}

		void ConfigureTest ()
		{
			var configurator = ConfigureApp.iOS
				.AppBundle (PathToIPA);


			_app = configurator.StartApp ();
		}

		[Test]
		public void FirstTest ()
		{

			ConfigureTest ();
			_app.Flash (c => c.Marked ("ExampleTextField"));
			_app.EnterText (c => c.Marked ("ExampleTextField"), "hello uitest");
//			_app.Repl ();


			Assert.True (true);
		}
	}
}


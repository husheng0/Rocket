using Rocket.API.Serialisation;
using NUnit.Framework;
using System.IO;
using Rocket.API.Assets;
using Rocket.Core.Providers.Permissions;
using Rocket.Core.Tests.Mock;

namespace Rocket.Core.Tests
{
    [TestFixture]
    public class RocketPermissionsHelperTest
    {
        RocketPermissionsHelper target = new RocketPermissionsHelper(new XMLFileAsset<RocketPermissions>(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Permissions.config.xml")));

        TestingPlayer p = new TestingPlayer();
        TestingPlayer p2 = new TestingPlayer("2");
        TestingPlayer p3 = new TestingPlayer("3",true);


        [Test]
        public void HasPermission()
        {
            //Assert.IsTrue(target.CheckPermission(p, new List<string>() { "p" }));
            //Assert.IsFalse(target.CheckPermission(p, new List<string>() { "p.reload" }));
            //Assert.IsTrue(target.CheckPermission(p, new List<string>() { "kit" }));
            //Assert.IsTrue(target.CheckPermission(p, new List<string>() { "kit.test" }));
            //Assert.IsTrue(target.CheckPermission(p, new List<string>() { "kit.test2" }));
            //Assert.IsTrue(target.CheckPermission(p, new List<string>() { "kit.test2.test3" }));

            //Assert.IsTrue(target.CheckPermission(p2, new List<string>() { "p" }));
            //Assert.IsFalse(target.CheckPermission(p2, new List<string>() { "p.reload" }));
            //Assert.IsTrue(target.CheckPermission(p2, new List<string>() { "kit" }));
            //Assert.IsFalse(target.CheckPermission(p2, new List<string>() { "kit.test" }));
            //Assert.IsTrue(target.CheckPermission(p2, new List<string>() { "kit.test2" }));

            //Assert.IsTrue(target.CheckPermission(p3, new List<string>() { "p" }) || p3.IsAdmin);
            //Assert.IsTrue(target.CheckPermission(p3, new List<string>() { "p.reload" }) || p3.IsAdmin);
            //Assert.IsTrue(target.CheckPermission(p3, new List<string>() { "kit" }) || p3.IsAdmin);
            //Assert.IsTrue(target.CheckPermission(p3, new List<string>() { "kit.test" }) || p3.IsAdmin);
            //Assert.IsTrue(target.CheckPermission(p3, new List<string>() { "kit.test2" }) || p3.IsAdmin);
            //Assert.IsTrue(target.CheckPermission(p3, new List<string>() { "kit.test2.test3" }) || p3.IsAdmin);
            //Assert.IsTrue(target.CheckPermission(p3, new List<string>() { "dummy" }) || p3.IsAdmin);
        }
    }
}

namespace SADZFP.Domain.Testing;
using SADZFP.domain.Catalog;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Can_Create_New_Rating()
    {
        var rating = new Rating(1, "Mike", "Great fit!");

        Assert.AreEqual(1, rating.Stars);
        Assert.AreEqual("Mike", rating.UserName);
        Assert.AreEqual("Great fit!", rating.Review);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_Rating_with_Invalid_Stars()
    {
        var rating = new Rating(0, "Mike", "Great fit!");
    }
}
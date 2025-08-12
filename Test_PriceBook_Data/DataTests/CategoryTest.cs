using System.Diagnostics;
using PriceBook_Data;
using SgUtil;

namespace PriceBook_Test.DataTests;

[TestClass]
public class CategoryTest
{

    [TestMethod]
    public void CategoryCrud()
    {
        string categoryName = WorkerResources.GetRandomString(10);
        string categoryNameUpdated = WorkerResources.GetRandomString(20);

        
        // Add category
        Category catAdd = new Category
        {
            Name = categoryName
        };
        catAdd.Add();

        int catId = catAdd.Id;

        // Get category and confirm values.
        Category catGetUpdate = new Category(catId);
        bool success = catGetUpdate.Equals(catAdd);
        success = success && catGetUpdate.Name == categoryName;
        Assert.IsTrue(success);

        // Update category Name
        catGetUpdate.Name = categoryNameUpdated;
        catGetUpdate.SaveUpdate(true);

        Category catCheckUpdate = new Category(catGetUpdate.Id);
        success = catCheckUpdate.Equals(catGetUpdate) && catCheckUpdate.Name == categoryNameUpdated;
        Assert.IsTrue(success);

        Category catDelete = new Category(catId);
        catDelete.Delete();

    }

    [TestMethod]
    public void CategoryNameUnique()
    {
        const string catName = "Dairy";
        Category cat = new Category
        {
            Name = catName
        };
        try
        {
            cat.Add();
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
        {
            string errorMsg =
                "Cannot insert duplicate key row in object 'dbo.Categories' with unique index 'IX_Categories_Name'.The duplicate key value is (Dairy).";
            Debug.Assert(e.InnerException != null, "e.InnerException != null");
            if (e.InnerException.Message == errorMsg) Assert.IsTrue(true); // asserting exception is correctly thrown.

        }
    }


    [TestMethod]
    public void CategoryConstructoErrorCatIdInput()
    {
        int catId = int.MaxValue; // to ensure no category id exists;
        bool success = false;
        string errorInfo = "";
        try
        {
            Category unused = new Category(catId);
        }
        catch (ApplicationException)
        {
            success = true;
            errorInfo = "Correct exception thrown on no category id.";
        }
        catch (Exception e)
        {
            errorInfo = "Some other error thrown." + e.Message;
        }
        Assert.IsTrue(success, errorInfo);
    }

    [TestMethod]
    public void CategoryConstructoErrorCatNInput()
    {
        int catId = int.MaxValue; // to ensure no category id exists;
        bool success = false;
        string errorInfo = "";
        try
        {
            Category unused = new Category(catId);
        }
        catch (ApplicationException)
        {
            success = true;
            errorInfo = "Correct exception thrown on no category id.";
        }
        catch (Exception e)
        {
            errorInfo = "Some other error thrown." + e.Message;
        }
        Assert.IsTrue(success, errorInfo);
    }

    [TestMethod]
    public void Inequality()
    {
        // id 
        Category first = new Category()
        {
            Id = 50,
            Name = "A crazy category"
        };

        Category second = new Category()
        {
            Id = 51,
            Name = "A crazy category"
        };

        bool success = !second.Equals(first);
        Assert.IsTrue(success);

        // name
        second = new Category()
        {
            Id = 50,
            Name = "Not like us"
        };
        success = !second.Equals(first);
        Assert.IsTrue(success);

    }
}

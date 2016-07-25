using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Salon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=DEUXEXMACHINA\\SQLEXPRESS;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_CategoriesEmptyAtFirst()
    {
      int result = Client.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      Client firstClient = new Client("Harry Styles", "Be Careful with the Styles Style", 1);
      Client secondClient = new Client("Harry Styles", "Be Careful with the Styles Style", 1);

      Assert.Equal(firstClient, secondClient);
    }
    public void Dispose()
    {
      // Client.DeleteAll();
      // Stylist.DeleteAll();
    }
  }
}

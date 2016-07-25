using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namspace Salon
{
  public class Client
  {
    private int _id;
    private string _name;
    private string _notes;
    private int _stylistId;

    public Client(string Name, string Notes, int StylistId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _notes = Notes;
      _stylistId = StylistId;
    }

    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.GetId() == newClient.GetId();
        bool nameEquality = this.GetName() == newClient.GetName();
        bool notesEquality = this.GetNotes() == newClient.GetNotes();
        bool stylistIdEquality = this.GetStylistId() == newClient.GetStylistId();
        return (idEquality && nameEquality && notesEquality && stylistIdEquality);
      }
      public int GetId()
      {
        return _id;
      }
      public string GetName()
      {
        return _name;
      }
      public void SetName(string newName)
      {
        _name = newName;
      }
      public string GetNotes()
      {
        return _notes;
      }
      public void SetNotes(string newNotes)
      {
        _notes = newNotes;
      }
      public int GetStylistId()
      {
        return _stylistId
      }
      public void SetStylistId(string newStylistId)
      {
        _stylistId = newStylistId;
      }
      public static List<Client> GetAll()
      {
        List<Client> allClients = new List<Client>{};

        SqlConnection conn = DB.Connection();
        SqlDataReader rdr = null;
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM client", conn);
        rdr = cmd.ExecuteReader();

        while(rdr.Read())
        {
          int clientId = rdr.GetInt32(0);
          string clientName = rdr.GetString(1);
          string clientNotes = rdr.GetString(2);
          int clientStylistId = rdr.GetInt32(3);
          Client newClient = new Client(clientName, clientNotes, clientStylistId, clientId);
          allClients.Add(newClient);
        }
        if(rdr != null)
        {
          rdr.Close();
        }
        if(conn != null)
        {
          conn.Close();
        }
        return allClients;
      }
    }
  }
}

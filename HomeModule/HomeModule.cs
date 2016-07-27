using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using System;

namespace Salon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["index.cshtml", AllStylists];
      };
      Post["/stylists/new"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["index.cshtml", Stylist.GetAll()];
      };
      Delete["/stylist/{id}/delete"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        SelectedStylist.Delete();
        return View["index.cshtml", Stylist.GetAll()];
      };
      Get["/stylists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var SelectedStylist = Stylist.Find(parameters.id);
        List<Client> StylistClients = SelectedStylist.GetClients();
        model.Add("stylist", SelectedStylist);
        model.Add("clients", StylistClients);
        return View["stylist.cshtml", model];
      };
      Post["/stylist/newclient"] = _ => {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["client-notes"], Request.Form["stylist-id"]);
        newClient.Save();
        return View["success.cshtml"];
      };
      Delete["/stylist/clientdelete/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        SelectedClient.Delete();
        return View["success.cshtml"];
      };
      Get["/stylist/edit/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        return View["stylist_edit.cshtml", SelectedStylist];
      };
      Patch["/stylist/edit/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        SelectedStylist.Update(Request.Form["stylist-name"]);
        return View["success.cshtml"];
      };
      Get["/client/edit/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        return View["client_edit.cshtml", SelectedClient];
      };
      Patch["/client/edit/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        SelectedClient.Update(Request.Form["client-name"], Request.Form["client-notes"]);
        return View["success.cshtml"];
      };

    }
  }
}

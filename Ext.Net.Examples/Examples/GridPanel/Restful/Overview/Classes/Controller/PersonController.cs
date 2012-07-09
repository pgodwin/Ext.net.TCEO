using System;

namespace Ext.Net.Examples.Restful
{
    public class PersonController : Controller
    {
        public override Response View()
        {
            var r = new Response(true, "Loaded data");
            r.Data = JSON.Serialize(Model.GetAll<PersonModel>());
            return r;
        }

        public override Response Create()
        {
            var added = JSON.Deserialize<PersonModel>(this.Request.Data).Insert<PersonModel>();

            var r = new Response(added != null, added != null ? "Created new Person" : "Failed to create Person");
            r.Data = added != null ? JSON.Serialize(added) : null;
            return r;
        }

        public override Response Update()
        {
            var updated = JSON.Deserialize<PersonModel>(this.Request.Data);
            updated.Id = this.Request.Id;
            updated = updated.Update<PersonModel>();

            var r = new Response(updated != null, updated != null ? "Updated Person" : "Failed to find that Person");
            r.Data = updated != null ? JSON.Serialize(updated) : null;
            return r;
        }

        public override Response Destroy()
        {
            var destroyed = PersonModel.Read<PersonModel>(this.Request.Id);
            destroyed = destroyed.Destroy<PersonModel>();

            var r = new Response(destroyed != null, destroyed != null ? "Destroyed Person" : "Failed to destroy Person");
            return r;
        }
    }
}

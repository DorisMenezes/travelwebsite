using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCWebsite.model;

namespace MVCWebsite.db.DbOperations
{
   public class DestinationRepository
    {
        public List<DestinationModel> GetAllDest()
        {

            using (var context = new TravelAgencyEntities())
            {
                var result = context.tbl_Destination.Select(x => new DestinationModel()
                {
                    Name=x.Name,
                    Price=x.Price,
                    Description=x.Description,
                    ImagePath=x.ImagePath,
                    IsOffer=x.IsOffer
                }
                ).ToList();
                return result;
            }
        }

        public int AddClient(ClientsModel model)

        {

            using (var context = new TravelAgencyEntities())
            {
                tbl_Clients clients = new tbl_Clients()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.EmailId,
                    EmailId = model.EmailId,
                    MobileNo = model.MobileNo,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Password=model.Password


                };

                context.tbl_Clients.Add(clients);
                context.SaveChanges();
                return clients.Id;
            }
        }

        public bool checkLogin(ClientsModel model)
        {
            using (var context = new TravelAgencyEntities())
            {
                bool isvalid = context.tbl_Clients.Any(x => x.Username == model.Username && x.Password == model.Password);

                return isvalid;
            }

        }
        public int AddContacts(ContactModel model)
        {
            using (var context = new TravelAgencyEntities())
            {
                tbl_Contact contact = new tbl_Contact()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    MessageBody = model.MessageBody,
                    EmailSent = true,
                    TimeStamp = System.DateTime.Now
                    


                };

                context.tbl_Contact.Add(contact);
                context.SaveChanges();
                return contact.Id;
            }

        }
    }
}

using Data.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Data.DbInitializer
{
    public class AtmDbInitializer : CreateDatabaseIfNotExists<AtmContext>
    {
        protected override void Seed(AtmContext context)
        {
            base.Seed(context);

            context.Cards.AddRange(new List<Card>
            {
                new Card {Balance = 20000, CardNumber = "1456741236541235", PinHash = "xKBS3ie+tNHJEprv8i4VlNoYW1/M6yHJqZ9lLUazvKI=" /*1111*/, ID = 0, IsBlocked = false },
                new Card {Balance = 30000, CardNumber = "6457985312478965", PinHash = "WUdXuqW7hbwki+H3WZ9pZ2/2fe4tX5fELRUASuSM4Ok=" /*2419*/, ID = 1, IsBlocked = false  },
                new Card {Balance = 70000, CardNumber = "9458741236547890", PinHash = "zwBfw2oeNsVdfFwaS6Z1CwZiNw/UDlBaI0LaYbeM8W0=" /*0837*/, ID = 2, IsBlocked = true  },
                new Card {Balance = 10000, CardNumber = "9451034700368422", PinHash = "qjnlJckzqOHn8zV6XkFabR7Om12jAmE+k1Lkx8tD6Y8=" /*5099*/, ID = 3, IsBlocked = false  }
            });

            context.SaveChanges();
        }
    }
}

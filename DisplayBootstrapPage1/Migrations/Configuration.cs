namespace DisplayBootstrapPage1.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DisplayBootstrapPage1.DAL.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DisplayBootstrapPage1.DAL.ShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (!context.Products.Any())
            {
                var InitReviews = new List<Review> {
                    new Review { ID = 1, UserName = "Anonymous", Text = "This product was great in terms of quality. I would definitely buy another!", Grade = "4" , PublishDate=DateTime.Parse("2015-08-01")},
                    new Review { ID = 2, UserName = "Furious",   Text = "Customer service sucks, sucks, sucks. Impotent and unwilling to do anything to handle my concerns. I will find a lawyer and end up filing charges.", Grade = "1", PublishDate=DateTime.Parse("2015-07-01") },
                    new Review { ID = 3, UserName = "Anonymous", Text = "Kan bara säga att jag är super nöjd allt! Känns jäkligt nice iaf, och snygg är den oxå.", Grade = "5", PublishDate=DateTime.Parse("2015-06-01") },
                    new Review { ID = 4, UserName = "Anonymous", Text = "I've alredy ordered another one!", Grade = "5", PublishDate=DateTime.Parse("2015-05-01") },
                    new Review { ID = 5, UserName = "Nöjdkund",  Text = "Helt sjukt grym!", Grade = "4", PublishDate=DateTime.Parse("2015-04-01") },
                    new Review { ID = 6, UserName = "Anonymous", Text = "Fan vad jag älskar den! Men nu vill jag testa även en med mer mumma.", Grade = "5", PublishDate=DateTime.Parse("2015-03-01") },
                    new Review { ID = 7, UserName = "Anonymous", Text = "Terrible, just don't waste your money or time with it!", Grade = "2", PublishDate=DateTime.Parse("2015-02-01") },
                    new Review { ID = 8, UserName = "Anonymous", Text = "I've seen some better than this, but not at this price. I definitely recommend this item.", Grade = "5", PublishDate=DateTime.Parse("2015-01-01") },
                    new Review { ID = 9, UserName = "Anonymous", Text = "Product was perfect for my needs. I was a bit nervous about it being Certified Pre-owned, but I quickly realized that these phones are not a bad deal. You get the same 1 year warranty as if it were new and if I had not been told it's Certified Pre-owned, I probably would not have known, LOL. The box is original OEM and all the accessories were OEM/original. There is a sticker on the front of the box that states it's Certified Pre-owned. Great bang for your buck here, Go for it if your thinking about buying this product.", Grade = "4", PublishDate=DateTime.Parse("2015-01-04") },
                    new Review { ID = 10, UserName = "Anonymous", Text = "I was leery of purchasing a Samsung product, however, this has been perfect. No issues whatsoever, long battery life, and it charges quickly.", Grade = "3", PublishDate=DateTime.Parse("2015-01-01") },
                    new Review { ID = 11, UserName = "Anonymous", Text = "Love this computer. never one issue.", Grade = "5", PublishDate=DateTime.Parse("2015-11-01") },
                    new Review { ID = 12, UserName = "Anonymous", Text = "would buy it again.", Grade = "5", PublishDate=DateTime.Parse("2015-01-19") },
                    new Review { ID = 13, UserName = "Anonymous", Text = "I cannot emphasize this enough - DO NOT BUY THIS PRODUCT.", Grade = "1", PublishDate=DateTime.Parse("2015-03-01") },
                    new Review { ID = 14, UserName = "salekwalker", Text = "Feeling like I would be told that I simply dropped it or something. I am sending it back. Total waste of time.", Grade = "1", PublishDate=DateTime.Parse("2015-01-01") },
                    new Review { ID = 15, UserName = "Anonymous", Text = "Outstanding value considering the one year warranty.", Grade = "5", PublishDate=DateTime.Parse("2015-01-01") },
                    new Review { ID = 16, UserName = "Oilman", Text = "after using this product for two months, even I don't know how to do next, because already past the return period.!.", Grade = "1", PublishDate=DateTime.Parse("2015-01-01") },
                    new Review { ID = 17, UserName = "Shatara Hinnant",  Text = "No problems or issues with it. Happy with my purchase.", Grade = "5", PublishDate=DateTime.Parse("2016-04-01") },
                    new Review { ID = 18, UserName = "Brian D.",  Text = "The screen produces the clearest, richest, and sharpest picture I have ever seen on any device. Plus it is extremely water resistant.", Grade = "4", PublishDate=DateTime.Parse("2016-05-02") },
                    new Review { ID = 19, UserName = "Kelly",  Text = "I'm very happy with my router thanks for the router i plan on getting my mom one around Christmas", Grade = "5", PublishDate=DateTime.Parse("2015-04-01") },
                    new Review { ID = 20, UserName = "Customer",  Text = "okay battery too short, about 8 hrs", Grade = "3", PublishDate=DateTime.Parse("2015-04-01") },
                    new Review { ID = 21, UserName = "Rocky Yeung",  Text = "THIS BATTERY IS WOREST", Grade = "1", PublishDate=DateTime.Parse("2015-04-01") },
                };

                InitReviews.ForEach(s => context.Reviews.Add(s));

                var InitProducts = new List<Product> {

                new Product{ID = 1, Name="Ipad Air 2", SubName = "9.7 64GB Rymdgrå",  Category ="Tablet", Manufacturer= "Apple", Price="6304",
                            Description = "Förändringen ligger i dina händer.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/apple-ipad-air-2-wi-fi-97-16gb-rymdgra-stor.tif",
                            PictureLinkSmall = "/Content/Images/apple-ipad-air-2-wi-fi-97-16gb-rymdgra.tif",
                            InStock = "15",
                            AverageReview = "3",
                            NumberReviews = 3,

                            Description2 = "2048 x 1536 screen resolution </br> iOS 7 operating system </br> 5MP iSight camera </br> Up to 10 hours of battery life </br> 1.4Ghz A7 processor",

                            },

                new Product{ID = 2, Name="250 G4 Core i5", SubName = "8GB 128GB SSD 15.6", Category = "Laptop", Manufacturer= "HP", Price="5590",
                            Description = "Otroligt prisvärd bärbar från HP med Windows 10 Pro.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/hp-250-g4-core-i5-8gb-128gb-ssd-156-stor.jpg",
                            PictureLinkSmall = "/Content/Images/hp-250-g4-core-i5-8gb-128gb-ssd-156.jpg",
                            InStock = "10",
                            AverageReview = "5",
                            NumberReviews = 3,

                            Description2 = "Processortyp Core i5 </br> Klockfrekvens 2.3 GHz </br> Cachestorlek 3 MB </br> Max. Turbofrekvens 2.8 GHz </br> Processorgeneration 6 </br> Processortillverkare Intel </br> Processormodell I5-6200U </br>  Antal kärnor Dubbelkärnig",

                            },

                new Product{ID = 3, Name="B50-50", SubName = "Core i3 4GB 128GB SSD 15.6", Category = "Laptop", Manufacturer= "Lenovo", Price="3490",
                            Description = "Riktigt prisvärd dator som både är tunn och lätt.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/lenovo-b50-50-core-i3-4gb-128gb-ssd-156-stor.jpg",
                            PictureLinkSmall = "/Content/Images/lenovo-b50-50-core-i3-4gb-128gb-ssd-156.jpg",
                            InStock = "11",
                            AverageReview = "4",
                            NumberReviews = 2,

                            Description2 = " Processortyp Core i3  </br> Klockfrekvens 2 GHz </br> Cachestorlek 3 MB </br> Processorgeneration 5 </br> Processortillverkare Intel </br> Processormodell I3-5005U </br> Antal kärnor Dubbelkärnig", 

                            },

                new Product{ID = 4, Name="F553SA", SubName = "Celeron 4GB 128GB SSD 15.6", Category = "Laptop", Manufacturer= "ASUS", Price="2790",
                            Description = "Användarcentrerad 15 tums bärbar dator för vardaglig användning.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/asus-f553sa-celeron-4gb-128gb-ssd-156-stor.jpg",
                            PictureLinkSmall = "/Content/Images/asus-f553sa-celeron-4gb-128gb-ssd-156.jpg",
                            InStock = "12",
                            AverageReview = "4",
                            NumberReviews = 1,
                            },

                new Product{ID = 5, Name="TabPro S", SubName = "Pro 4G Core M 4GB 128GB 12", Category = "Laptop", Manufacturer= "Samsung", Price="12990",
                            Description = "En smart kombination av två produkter i en, både PC och tablet.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/samsung-tabpro-s-pro-4g-core-m-4gb-128gb-12-stor.jpg",
                            PictureLinkSmall = "/Content/Images/samsung-tabpro-s-pro-4g-core-m-4gb-128gb-12.jpg",
                            InStock = "9",
                            AverageReview = "3",
                            NumberReviews = 1,
                            },

                new Product{ID = 6, Name="MacBook", SubName = "Pro 8GB 128GB SSD 13.3", Category = "Laptop", Manufacturer= "Apple", Price="13790",
                            Description = "Mer kraft bakom varje pixel.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/apple-macbook-pro-with-retina-display-core-i5-8gb-128gb-ssd-133-stor.tif",
                            PictureLinkSmall = "/Content/Images/apple-macbook-pro-with-retina-display-core-i5-8gb-128gb-ssd-133.jpg",
                            InStock = "18",
                            AverageReview = "5",
                            NumberReviews = 1,

                            Description2 = "12-tums Retina-skärm </br> Intel Core m3-processor </br> 128GB Flashlagring",

                            },

                new Product{ID = 7, Name="Archer", SubName = "C2600", Category = "Router", Manufacturer= "TP-Link", Price="1899",
                            Description = "MU-MIMO för avbrottsfri underhållning på alla dina enheter.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/tp-link-archer-c2600-stor.jpg",
                            PictureLinkSmall = "/Content/Images/tp-link-archer-c2600.jpg",
                            InStock = "31",
                            AverageReview = "5",
                            NumberReviews = 1,
                            },

                 new Product{ID = 8, Name="Galaxy", SubName = "Tab A 9.7 16GB Svart", Category = "Tablet", Manufacturer= "Samsung", Price="2335",
                            Description = "Njut av surf, mejl, spel och läsning.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/samsung-galaxy-tab-a-97-16gb-svart-stor.jpg",
                            PictureLinkSmall = "/Content/Images/samsung-galaxy-tab-a-97-16gb-svart.jpg",
                            InStock = "32",
                            AverageReview = "1",
                            NumberReviews = 2,
                            },

                new Product{ID = 9, Name="Galaxy", SubName = "Tab S2 A 9.7 32GB Svart", Category = "Tablet", Manufacturer= "Samsung", Price="3829",
                            Description = "Samsungs tunnaste tablet hittills.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/samsung-galaxy-tab-s2-97-32gb-svart-stor.jpg",
                            PictureLinkSmall = "/Content/Images/samsung-galaxy-tab-s2-97-32gb-svart.jpg",
                            InStock = "33",
                            AverageReview = "5",
                            NumberReviews = 1,
                            },

                new Product{ID = 10, Name="ZenPad C 7.0", SubName = "Z170C 7 16GB Svart", Category = "Tablet", Manufacturer= "ASUS", Price="1109",
                            Description = "Stilren 7-tums budgetvänlig datorplatta för normal underhållning", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/asus-zenpad-c-70-z170c-7-16gb-svart-stor.jpg",
                            PictureLinkSmall = "/Content/Images/asus-zenpad-c-70-z170c-7-16gb-svart.jpg",
                            InStock = "34",
                            AverageReview = "1",
                            NumberReviews = 1,
                            },

                new Product{ID = 11, Name="GALAXY", SubName = "S6 Edge 32GB Vit", Category = "Smartphone", Manufacturer= "Samsung", Price="5290",
                            Description = "En smakfull fusion mellan glas och metall.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/samsung-galaxy-s6-edge-32gb-vit-stor.jpg",
                            PictureLinkSmall = "/Content/Images/samsung-galaxy-s6-edge-32gb-vit.jpg",
                            InStock = "35",
                            AverageReview = "5",
                            NumberReviews = 1,
                            },

                new Product{ID = 12, Name="Galaxy S6", SubName = "32GB Blå", Category = "Smartphone", Manufacturer= "Samsung", Price="4999",
                            Description = "En fusion mellan glas och metall som utstrålar innovation.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/samsung-galaxy-s6-32gb-bla-stor.jpg",
                            PictureLinkSmall = "/Content/Images/samsung-galaxy-s6-32gb-bla.jpg",
                            InStock = "36",
                            AverageReview = "4",
                            NumberReviews = 1,
                            },

                new Product{ID = 13, Name="iPhone 6s", SubName = "16GB Rosa Guld", Category = "Smartphone", Manufacturer= "Apple", Price="6490",
                            Description = "Det är bara en sak som förändrats. Allt.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/apple-iphone-6s-16gb-rosa-guld-stor.jpg",
                            PictureLinkSmall = "/Content/Images/apple-iphone-6s-16gb-rosa-guld.jpg",
                            InStock = "27",
                            AverageReview = "2",
                            NumberReviews = 2,

                            Description2 = "iOS och A8-chip </br> 5,5 Retina HD-skärm </br> Fingeravtrycksläsare",

                            },

                new Product{ID = 14, Name="RangeMax", SubName = "WNR1000v2", Category = "Router", Manufacturer= "Netgear", Price="349",
                            Description = "Med 1 högpresterande antenn för maximal räckvidd.", PublishDate=DateTime.Parse("2015-09-01"),
                            PictureLinkLarge = "/Content/Images/netgear-rangemax-wnr1000v2-stor.jpg",
                            PictureLinkSmall = "/Content/Images/netgear-rangemax-wnr1000v2.jpg",
                            InStock = "4",
                            AverageReview = "5",
                            NumberReviews = 1,
                            },

                new Product{ID = 15, Name="Chromebook", SubName = "11 G4 Celeron 16GB SSD 11.6", Category = "Laptop", Manufacturer= "HP", Price="3999",
                            Description = "Kraftfull prestanda.", PublishDate=DateTime.Parse("2016-04-01"),
                            PictureLinkLarge = "/Content/Images/hp-chromebook-11-g4-celeron-4gb-16gb-ssd-116-stor.jpg",
                            PictureLinkSmall = "/Content/Images/hp-chromebook-11-g4-celeron-4gb-16gb-ssd-116.jpg",
                            InStock = "0",
                            AverageReview = "5",
                            NumberReviews = 0,

                            Description2 = "Processortyp Celeron </br> Klockfrekvens 2.16 GHz </br> Max. Turbofrekvens 2.58 GHz </br> Processormodell N2840 </br> Antal kärnor Dubbelkärnig",

                            }
                };

                InitProducts[0].Reviews.Add(InitReviews[0]);
                InitProducts[0].Reviews.Add(InitReviews[1]);
                InitProducts[0].Reviews.Add(InitReviews[2]);

                InitProducts[1].Reviews.Add(InitReviews[3]);
                InitProducts[1].Reviews.Add(InitReviews[4]);
                InitProducts[1].Reviews.Add(InitReviews[5]);

                InitProducts[2].Reviews.Add(InitReviews[6]);
                InitProducts[2].Reviews.Add(InitReviews[7]);

                InitProducts[3].Reviews.Add(InitReviews[8]);

                InitProducts[4].Reviews.Add(InitReviews[9]);

                InitProducts[5].Reviews.Add(InitReviews[10]);

                InitProducts[6].Reviews.Add(InitReviews[11]);

                InitProducts[7].Reviews.Add(InitReviews[12]);
                InitProducts[7].Reviews.Add(InitReviews[13]);

                InitProducts[8].Reviews.Add(InitReviews[14]);

                InitProducts[9].Reviews.Add(InitReviews[15]);

                InitProducts[10].Reviews.Add(InitReviews[16]);

                InitProducts[11].Reviews.Add(InitReviews[17]);


                InitProducts[12].Reviews.Add(InitReviews[19]);
                InitProducts[12].Reviews.Add(InitReviews[20]);

                InitProducts[13].Reviews.Add(InitReviews[18]);

                InitProducts.ForEach(s => context.Products.Add(s));

                //Debug.WriteLine("My debug string here");

                context.SaveChanges();
            }
        }
    }
}

using CatorisCityAppNew.Viewmodels;
using CityAppServices.Objects.Entities;
using CityAppServices.Objects.database;
using CityAppServices;
namespace CatorisCityAppNew.Objects
{
    public static class SampleData

    {
  
        public static async void CreateSampleUsers()
        {
 
            PersonEntity newPersonEntity = new PersonEntity();
            PersonEntity PersonEntity = new PersonEntity();
            PersonEntity catoriPersonEntity = new PersonEntity();
            PersonEntity badperson1Entity = new PersonEntity();
            PersonEntity badperson2Entity = new PersonEntity();
            PersonEntity badperson3Entity = new PersonEntity();
            PersonEntity badperson4Entity = new PersonEntity();

            PersonImageEntity image1 = new PersonImageEntity();
            image1.Name = "girl_1";
            image1.FilePath = "girl_1.jpg";
            image1.PersonImageType = PersonImageTypeEnum.Normal;
            image1.FKPersonId = newPersonEntity.PersonId;
            image1.PersonImageStatus = PersonImageStatusEnum.LookingRight45;
            GlobalServices.ImageRepository.UpsertPersonImage(image1);
            image1 = new PersonImageEntity();
            image1.Name = "girl_1_head";
            image1.FilePath = "girl_1_head.jpg";
            image1.PersonImageType = PersonImageTypeEnum.Normal;
            image1.FKPersonId = 0;
            image1.PersonImageStatus = PersonImageStatusEnum.LookingRight45;
            GlobalServices.ImageRepository.UpsertPersonImage(image1);
            image1 = new PersonImageEntity();
            image1.Name = "girl_2_slacks_45deg";
            image1.FilePath = "girl_2_slacks_45deg.jpg";
            image1.PersonImageType = PersonImageTypeEnum.Normal;
            image1.FKPersonId = 0;
            image1.PersonImageStatus = PersonImageStatusEnum.HeadLookingLeft45;
            GlobalServices.ImageRepository.UpsertPersonImage(image1);
            image1 = new PersonImageEntity();
            image1.Name = "girl_2_slacks_front";
            image1.FilePath = "girl_2_slacks_front.jpg";
            image1.PersonImageType = PersonImageTypeEnum.Normal;
            image1.FKPersonId = 0;
            image1.PersonImageStatus = PersonImageStatusEnum.Facing;
            GlobalServices.ImageRepository.UpsertPersonImage(image1);
            image1 = new PersonImageEntity();
            image1.Name = "girl_2_slacks_side";
            image1.FilePath = "girl_2_slacks_side.jpg";
            image1.PersonImageType = PersonImageTypeEnum.Normal;
            image1.FKPersonId = 0;
            image1.PersonImageStatus = PersonImageStatusEnum.LookingLeft;
            GlobalServices.ImageRepository.UpsertPersonImage(image1);

            catoriPersonEntity = await GlobalServices.InsertPersonAsync("Catori", true, PersonEnum.Individual,"girl_8.png");
            newPersonEntity = await GlobalServices.InsertPersonAsync("Joe", false, PersonEnum.Individual, "man_1.png");
            newPersonEntity = await GlobalServices.InsertPersonAsync("Jeff", false, PersonEnum.Individual, "man_1.png");
            newPersonEntity = await GlobalServices.InsertPersonAsync("Quyen", false, PersonEnum.Individual, "girl_1.png");
            newPersonEntity = await GlobalServices.InsertPersonAsync("Papa", false, PersonEnum.Individual, "man_3.png");
            newPersonEntity = await GlobalServices.InsertPersonAsync("Gaga", false, PersonEnum.Individual, "girl_2_slacks_45deg.png");
            newPersonEntity = await GlobalServices.InsertPersonAsync("Sam", false, PersonEnum.Individual, "man_3.png");
            newPersonEntity = await GlobalServices.InsertPersonAsync("Byron", false, PersonEnum.Individual, "man_5.png");
            newPersonEntity = await GlobalServices.InsertPersonAsync("Dwayne", false, PersonEnum.Individual, "man_6.png");
            newPersonEntity = await GlobalServices.InsertPersonAsync("Merle", false, PersonEnum.Individual, "man_7.png");

            badperson1Entity = await GlobalServices.InsertPersonAsync("JohnD", false, PersonEnum.BadGuy, "badguy_2_smirk.png");
            badperson2Entity = await GlobalServices.InsertPersonAsync("BuggsyS", false, PersonEnum.BadGuy, "badguy_6_mad.png");
            badperson3Entity = await GlobalServices.InsertPersonAsync("ClydeB", false, PersonEnum.BadGuy, "badguy_3.png");
            badperson4Entity = await GlobalServices.InsertPersonAsync("DocH", false, PersonEnum.BadGuy, "badguy_4.png");


            GlobalServices.InsertPersonImage("badguy_6_armsdown", PersonImageTypeEnum.BadGuy, 
                PersonImageStatusEnum.Normal,
                   "badguy_6_armsdown.png", "Normal", badperson1Entity.PersonId);
            GlobalServices.InsertPersonImage("badguy_6_cashgun", PersonImageTypeEnum.BadGuy, 
                PersonImageStatusEnum.CashGun,
        "badguy_6_cashgun.png", "CashGun", badperson1Entity.PersonId);
            GlobalServices.InsertPersonImage("badguy_6_mad", PersonImageTypeEnum.BadGuy,
                PersonImageStatusEnum.Mad,
                    "badguy_6_mad.png", "Mad", badperson1Entity.PersonId);
            GlobalServices.InsertPersonImage("badguy_6_wcash", PersonImageTypeEnum.BadGuy, 
                PersonImageStatusEnum.Cash,
                    "badguy_6_wcash.png", "Cash", badperson1Entity.PersonId);
            GlobalServices.InsertPersonImage("badguy_6_withgun", PersonImageTypeEnum.BadGuy,
                PersonImageStatusEnum.Gun,
          "badguy_6_withgun.png", "Gun", badperson1Entity.PersonId);
            GlobalServices.InsertPersonImage("badguy_6_wloot", PersonImageTypeEnum.BadGuy, 
                PersonImageStatusEnum.Loot,
                      "badguy_6_wloot.png", "loot", badperson1Entity.PersonId);

            GlobalServices.InsertPersonImage("badguy_2_armsdown", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.ArmsDown,
                           "badguy_2_armsdown.png", "ArmsDown", badperson2Entity.PersonId);
            GlobalServices.InsertPersonImage("badguy_2_cashpiles", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.CashPiles,
                           "badguy_2_cashpiles.png", "CashPiles", badperson2Entity.PersonId);
            GlobalServices.InsertPersonImage("badguy_2_computer", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Computer,
                           "badguy_2_computer.png", "computer", badperson2Entity.PersonId);

            GlobalServices.InsertPersonImage("badguy_2_money", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Drinking,
                           "badguy_2_money.png", "Money", badperson2Entity.PersonId);

            GlobalServices.InsertPersonImage("badguy_2_smirk", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Drinking,
                          "badguy_2_smirk.png", "Smirk", badperson2Entity.PersonId);
            
            GlobalServices.InsertPersonImage("badguy_3", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Normal,
                          "badguy_3.png", "Drinking", badperson3Entity.PersonId);
            
            GlobalServices.InsertPersonImage("badguy_4", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Drinking,
                          "badguy_4.png", "Money", badperson4Entity.PersonId);
            GlobalServices.InsertPersonImage("badguy_4_armsup", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.ArmsUp,
                          "badguy_4armsup.png", "Arms Up", badperson4Entity.PersonId);
            GlobalServices.InsertPersonImage("badguy_4_mojojojo", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Drinking,
                          "badguy_4_mojojojo.png", "Drinking", badperson4Entity.PersonId);
            GlobalServices.InsertPersonImage("badguy_4_armsdown", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.ArmsDown,
                   "badguy_4_armsdown.png", "Arms Down", badperson4Entity.PersonId);
            GlobalServices.InsertPersonImage("badguy_4", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Devil,
                           "badguy_4.png", "Devil", badperson4Entity.PersonId);

            //GlobalServices.InsertImagetype("badguy_5amsout", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Normal,
            //   "badguy_5amsout.png", "Drinking", badperson1Entity.PersonId);
            //GlobalServices.InsertImagetype("badguy_4mojojojo", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Normal,
            //               "badguy_4mojojojo.png", "Drinking", 0);
           
            //GlobalServices.InsertImagetype("badguy_lootgun", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Normal,
            //               "badguy_lootgun.png", "Loot Gun", 0);
            //GlobalServices.InsertImagetype("badguy_mad", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Normal,
            //               "badguy_mad.png", "Mad", 0);

            //GlobalServices.InsertImagetype("badguy_wcash", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Cash,
            //               "badguy_wcash.jpg", "Cash", 0);
            //GlobalServices.InsertImagetype("badguy_withgun", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Gun,
            //                "badguy_withgun.jpg", "Gun", 0);
            //GlobalServices.InsertImagetype("badguy_wloot", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Loot,
            //                "badguy_wloot.jpg", "Loot", 0);

            GlobalServices.InsertPersonImage("girl_8", PersonImageTypeEnum.Normal, PersonImageStatusEnum.Facing,
                            "girl_8.png", "", catoriPersonEntity.PersonId);
            GlobalServices.InsertPersonImage("girl_8_airguitar", PersonImageTypeEnum.Normal, PersonImageStatusEnum.Airguitar,
                            "girl_8_airguitar.png", "", catoriPersonEntity.PersonId);
            GlobalServices.InsertPersonImage("girl_8_dancing", PersonImageTypeEnum.Normal, PersonImageStatusEnum.Dancig,
                            "girl_8_dancing.png", "", catoriPersonEntity.PersonId);
            GlobalServices.InsertPersonImage("girl_8_lookingback", PersonImageTypeEnum.Normal, PersonImageStatusEnum.LookimgBack,
                            "girl_8_lookingback.png", "", catoriPersonEntity.PersonId);
            GlobalServices.InsertPersonImage("girl_8_walking", PersonImageTypeEnum.Normal, PersonImageStatusEnum.Walking,
                            "girl_8_walking.png", "", catoriPersonEntity.PersonId);
  
            GlobalServices.InsertPersonImage("girl_3_fingerup", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Facing,
                                  "girl_3_fingerup.png", "", 0);
            GlobalServices.InsertPersonImage("man_1", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Facing,
                                  "man_1.jpg", "", 0);
            GlobalServices.InsertPersonImage("man_3", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Facing,
                                  "man_3.png", "", 0);

            GlobalServices.InsertBusiness("Jones Fin.", 200, "bank_1.jpg", BusinessTypeEnum.Financial);
            GlobalServices.InsertBusiness("123 Bank", 200, "bank_2.jpg", BusinessTypeEnum.Financial);
            GlobalServices.InsertBusiness("Iron Factory", 130, "factory_1.jpg", BusinessTypeEnum.Factory);
            GlobalServices.InsertBusiness("Auto Factory", 150, "factory_2.jpg", BusinessTypeEnum.Factory);

            GlobalServices.InsertHouse("Catories", "house_3d4.jpg", "living_10_roomarmchair.png", "kitchen_1_room.jpg", "garage_1.jpg", true, "Catories");

            GlobalServices.InsertHouse("Jeffs", "house_5_dkbrownroofgarage.jpg", "living__7_room.jpg", "kitchen_2_room.jpg", "garage_2.jpg", false, "Jeffs");
            GlobalServices.InsertHouse("Quyens", "house_3d4.jpg", "living_6_room.jpg", "kitchen_3_room.jpg", "garage_3.jpg", false, "Quyens");
            GlobalServices.InsertHouse("Joe", "house_3d4.jpg", "living__7_room.jpg", "kitchen_2_room.jpg", "garage_2.jpg", false, "Joe");
            GlobalServices.InsertHouse("Papa", "house_6_grayroofgarage.jpg", "living_11_roombig.png", "kitchen_3_room.jpg", "garage_1.jpg", false, "Papa");
            GlobalServices.InsertHouse("Gaga", "house_6_grayroofgarage.jpg", "living__7_room.jpg", "kitchen_2_room.jpg", "garage_3.jpg", false, "Gaga");
            GlobalServices.InsertHouse("Sara", "houase_13_3dwyard.jpg", "living_11_roombig.png", "kitchen1.jpg", "garage_2.jpg", false, "Sara");
            GlobalServices.InsertHouse("John", "house_3d4.jpg", "living__7_room.jpg", "kitchen_3_room.jpg", "garage_1.jpg", false, "John");
            GlobalServices.InsertHouse("Gary", "house_5_dkbrownroofgarage.jpg", "living_6_room.jpg", "kitchen_2_room.jpg", "garage_1.jpg", false, "Gary");
            GlobalServices.InsertHouse("Sue", "house_6_grayroofgarage.jpg", "living_11_roombig.png", "kitchen1.jpg", "garage_2.jpg", false, "Sue");
            GlobalServices.InsertHouse("Bill", "houase_13_3dwyard.jpg", "living__7_room.jpg", "kitchen_3_room.jpg", "garage_3.jpg", false, "Bill");
            GlobalServices.InsertHouse("Jack", "house_12_3ds2.jpg", "living_6_room.jpg", "kitchen_2_room.jpg", "garage_2.jpg", false, "Jack");
            GlobalServices.InsertHouse("June", "house_3d4.jpg", "living_6_room.jpg", "kitchen_2_room.jpg", "garage_2.jpg", false, "June");

            //newPersonEntity = await GlobalServices.InsertPersonAsync("Joe Skinny", false, PersonEnum.BadGuy);

            //newPersonEntity = await GlobalServices.InsertPersonAsync("Mojo", false, PersonEnum.BadGuy);
            //newPersonEntity = await GlobalServices.InsertPersonAsync("sue Devil", false, PersonEnum.BadGuy);
  

        }
    }
}

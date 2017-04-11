using Newtonsoft.Json;
using Resturant.BAL;
using Resturant.Models;
using Resturant.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant.Controllers
{
    public class AdminFoodController : Controller
    {
        //
        // GET: /AdminFood/

        public ActionResult Index()
        {
            return View();
        }
        #region Cousine Methods
        public ActionResult addCousine(Cousine _cousine)
        {
            BLFood blFood = new BLFood();
            blFood.addCousine(_cousine);
            var cousineList = blFood.getListOfCousine();
            ViewBag.cousineList = cousineList;
            return View("AddCousine");
        }

        public ActionResult deleteCousine(int _id)
        {
            BLFood blFood = new BLFood();
            blFood.deleteCousine(_id);
            var cousineList = blFood.getListOfCousine();
            ViewBag.cousineList = cousineList;
            return View("AddCousine");
        }

        public ActionResult displayUpdateCousine(int _id)
        {
            BLFood blfood = new BLFood();

            Category category = blfood.getCategoryById(_id);
            Cousine cousine = blfood.getCousineById(_id);
            ViewBag.Cousine = cousine;
            var cousineList = blfood.getListOfCousine();
            ViewBag.cousineList = cousineList;
            return View("UpdateCousine");

        }

        public ActionResult updateCousine(Cousine cousine)
        {
            new BLFood().updateCousine(cousine);
            return RedirectToAction("displayCousine");
        }
        public ActionResult displayCousine()
        {
            var cousineList = new BLFood().getListOfCousine();
            ViewBag.cousineList = cousineList;
            return View("AddCousine");
        }
        #endregion

        #region Category
        public ActionResult DisplayAddCategory()
        {
            BLFood blfood = new BLFood();
            List<Cousine> cousines = blfood.getListOfCousine();
            List<Category> category = blfood.getListOfCategory();
            ViewBag.Cousines = cousines;
            return View("AddCategory",category);
        }

        public ActionResult AddCategory(Category _category)
        {
            BLFood blfood = new BLFood();
            blfood.addCategory(_category);
            List<Cousine> cousines = blfood.getListOfCousine();
            List<Category> category = blfood.getListOfCategory();
            ViewBag.Cousines = cousines;
            return View("AddCategory", category);

        }
        public ActionResult DeleteCategory(int _id)
        {
            BLFood blFood = new BLFood();
            blFood.deleteCategory(_id);
            return RedirectToAction("DisplayAddCategory");
        }
        public ActionResult DisplayUpdateCategory(int _id)
        {
            BLFood blfood = new BLFood();

            Category category = blfood.getCategoryById(_id);
            List<Cousine> cousines = blfood.getListOfCousine();
            List<Category> categories = blfood.getListOfCategory();

            ViewBag.Cousines = cousines;
            ViewBag.Category = category;
            return View("UpdateCategory", categories);
        }
       
        public ActionResult UpdateCategory(Category _category)
        {
            new BLFood().updateCategory(_category);
            return RedirectToAction("DisplayAddCategory");
        }
        #endregion

        #region food
        public ActionResult DisplayAddFood()
        {
            BLFood blfood = new BLFood();
            List<Cousine> cousines = blfood.getListOfCousine();
            ViewBag.Cousines = cousines;
            List<Food> food = blfood.getListOfFood();
            return View("AddFood",food);
       

        }

        public ActionResult DisplayFoodList(int id)
        {
            BLFood blfood = new BLFood();
            Food food = blfood.getFoodById(id);
            ViewBag.Food_Size = blfood.getListOfFood_Sizes();
            ViewBag.Ingredients = blfood.getListOfIngredients();
            ViewBag.AddOn = blfood.getListOfAddon();
            return View("DisplayFood", food);
        }

        //Food Add Ingredients Metods Start
        public ActionResult deleteFoodIngredients(int _id)
        {
            BLFood blfood = new BLFood();
            Food_Ingredients fi = blfood.getFood_IngredientById(_id);
            blfood.deleteFood_Ingredient(_id);
            return RedirectToAction("DisplayFoodList", new { id = fi.FoodID });
        }


        public ActionResult AddFoodIngredients(int id,int FoodId)
        {
         
            Food_Ingredients foodIngredients = new Food_Ingredients { FoodID = FoodId, IngredientsID = id };
            BLFood blfood = new BLFood();
         
            blfood.addFood_Ingredient(foodIngredients);
            return RedirectToAction("DisplayFoodList", new { id = FoodId });
        }
        //Food Add Ingredients Metods Emd


        //Food Add On Metods Start

        //Food Add On
        public ActionResult AddFoodAddOn(int AddOnID, int FoodId)
        {
            Food_AddOn foodAddOn = new Food_AddOn { FoodId = FoodId, AddOnId = AddOnID };
            BLFood blfood = new BLFood();
            blfood.addFood_AddOn(foodAddOn);
            return RedirectToAction("DisplayFoodList", new { id = FoodId });
        }

        // delete food AddOn
        public ActionResult deleteFoodAddOn(int _id)
        {
            BLFood blfood = new BLFood();
            Food_AddOn fi = blfood.getFood_AddOnById(_id);
            blfood.deleteFood_AddOn(_id);
            return RedirectToAction("DisplayFoodList", new { id = fi.FoodId });
        }




        //Food Add On Metods End


        [HttpGet]
        public string getCategory(int cousineId)
        {
            List<Category> cats = new BLFood().getListOfCategoryByCousineId(cousineId);
          
            return JsonConvert.SerializeObject(cats, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
        }

        public ActionResult addFood(Food food)
        {
            BLFood blfood = new BLFood();
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~")+ProjectVaraiables.SERVERPATH + "\\" + file.FileName);
                    food.Image = @"..\" + ProjectVaraiables.SERVERPATH + "\\" + file.FileName;

                }
                


            }

            blfood.addFood(food);
            return RedirectToAction("DisplayAddFood");
        }

        public ActionResult deleteFood(int _id)
        {
            BLFood blFood = new BLFood();
            blFood.deleteFood(_id);
            return RedirectToAction("DisplayAddFood");
        }
        public ActionResult displayUpdateFood(int _id)
        {
            BLFood blfood = new BLFood();

            List<Cousine> cousines = blfood.getListOfCousine();
            ViewBag.Cousines = cousines;
            List<Food> foods = blfood.getListOfFood();

            Food food = blfood.getFoodById(_id);
            ViewBag.food = food;

            return View("UpdateFood", foods);
        }
        public ActionResult UpdateFood(Food _food)
        {
            string isChecked = Request.Form["ImgBox"];
             if (isChecked !=null)
             {
                 if (isChecked.Equals("on"))
                     _food.Image = string.Empty;
             }
             if (Request.Files.Count > 0)
             {
                 var file = Request.Files[0];

                 if (file != null && file.ContentLength > 0)
                 {
                     file.SaveAs(Server.MapPath("~") + ProjectVaraiables.SERVERPATH + "\\" + file.FileName);
                     _food.Image = @"..\" + ProjectVaraiables.SERVERPATH + "\\" + file.FileName;

                 }
                 


             }
            new BLFood().updateFood(_food);
            return RedirectToAction("DisplayAddFood");
        }

        #endregion


        #region Addon

        public ActionResult DisplayAddOn()
        {
            BLFood blfood = new BLFood();
   
            return View("AddAddon",  blfood.getListOfAddon());

        }
        public ActionResult addAddon(AddOn _addOn)
          {
              BLFood blfood = new BLFood();
              blfood.addAddOn(_addOn);
              return RedirectToAction("DisplayAddOn");
          }

        public ActionResult deleteAddOn(int _addOnId)
          {
              BLFood blFood = new BLFood();
              blFood.deleteAddon(_addOnId);
              return RedirectToAction("DisplayAddOn");
          }

        public ActionResult DisplayUpdateAddOn(int _id)
        {
            BLFood blfood = new BLFood();

            AddOn addOn = blfood.getAddOnById(_id);
            ViewBag.addOn = addOn;

            return View("UpdateAddOn", blfood.getListOfAddon());
        }

        public ActionResult UpdateAddOn(AddOn _addOn)
        {
            new BLFood().UpdateAddOn(_addOn);
            return RedirectToAction("DisplayAddOn");
        }
        
        #endregion

        #region Ingredients
        public ActionResult DisplayIngredients()
        {
            BLFood blfood = new BLFood();
            return View("AddIngredients", blfood.getListOfIngredients());

        }

        public ActionResult addIngredients(Ingredient _IngredientOn)
        {
            BLFood blfood = new BLFood();
            blfood.addIngredient(_IngredientOn);
            return RedirectToAction("DisplayIngredients");
        }

        public ActionResult deleteIngredients(int _Id)
        {
            BLFood blFood = new BLFood();
            blFood.deleteIngredient(_Id);
            return RedirectToAction("DisplayIngredients");
        }

        public ActionResult DisplayUpdateIngredients(int _id)
        {
            BLFood blfood = new BLFood();

            Ingredient ingredient = blfood.getIngredientById(_id);
            ViewBag.ingredient = ingredient;

            return View("UpdateIngredient", blfood.getListOfIngredients());
        }

        public ActionResult UpdateIngredients(Ingredient _ingredient)
        {
            new BLFood().UpdateIngredient(_ingredient);
            return RedirectToAction("DisplayIngredients");
        }
        #endregion

        #region FoodItem
        public ActionResult DisplayAddFoodItem()
        {
            BLFood blfood = new BLFood();
            List<Food> food = blfood.getListOfFood();
            List<FoodItem> foodItem = blfood.getListOfFoodItem();
            ViewBag.Food = food;
            return View("AddFoodItem", foodItem);
        }

        public ActionResult AddFoodItem(FoodItem _foodItem)
        {
            BLFood blfood = new BLFood();
            blfood.addFoodItem(_foodItem);
            return RedirectToAction("DisplayFoodList", new { id = _foodItem.FoodId });


        }

        public ActionResult deleteFoodItem(int _Id,int _foodId)
        {
            BLFood blFood = new BLFood();
            blFood.deleteFoodItem(_Id);
            return RedirectToAction("DisplayFoodList", new { id = _foodId });

        }

        public ActionResult DisplayUpdateFoodItem(int _id)
        {
            BLFood blfood = new BLFood();
            List<Food> food = blfood.getListOfFood();
            ViewBag.Food = food;
            FoodItem foodItem = blfood.getFoodItemById(_id);
            ViewBag.FoodItem = foodItem;
            return View("UpdateFoodItem", blfood.getListOfFoodItem());
        }

        public ActionResult UpdateFoodItem(FoodItem _foodItem)
        {
            new BLFood().updateFoodItem(_foodItem);
            return RedirectToAction("DisplayFoodList", new { id = _foodItem.FoodId });
        }
        #endregion

        #region Tax
        public ActionResult DisplayAddTax()
        {
            BLTax blTax = new BLTax();
            return View("AddTax", blTax.getListOfTax());
        }

        public ActionResult AddTax(Tax _Tax)
        {
            BLTax blTax = new BLTax();
            blTax.addTax(_Tax);

            return RedirectToAction("DisplayAddTax");

        }

        public ActionResult deleteTax(int _Id)
        {
            BLTax blTax = new BLTax();
            blTax.deleteTax(_Id);
            return RedirectToAction("DisplayAddTax");
        }

        public ActionResult DisplayUpdateTax(int _id)
        {
            BLTax blTax = new BLTax();
            Tax Tax = blTax.getTaxById(_id);
            ViewBag.Tax = Tax;
            return View("UpdateTax", blTax.getListOfTax());
        }

        public ActionResult UpdateTax(Tax _tax)
        {
            BLTax blTax = new BLTax();
            blTax.UpdateTax(_tax);
            return RedirectToAction("DisplayAddTax");
        }
        #endregion

        #region ExtraCharges
        public ActionResult DisplayAddExtraCharges()
        {
            BLExtraCharges blExtracharges = new BLExtraCharges();
            return View("AddExtraCharges", blExtracharges.getListOfExtraCharges());
        }

        public ActionResult AddExtraCharges(ExtraCharge _extraCharge)
        {
            BLExtraCharges blExtracharges = new BLExtraCharges();
            blExtracharges.addExtraCharges(_extraCharge);

            return RedirectToAction("DisplayAddExtraCharges");

        }

        public ActionResult deleteExtraCharges(int _Id)
        {
            BLExtraCharges blExtracharges = new BLExtraCharges();
            blExtracharges.deleteExtraCharges(_Id);
            return RedirectToAction("DisplayAddExtraCharges");
        }

        public ActionResult DisplayUpdateExtraCharges(int _id)
        {
            BLExtraCharges blExtracharges = new BLExtraCharges();
            ExtraCharge extraCharge = blExtracharges.getExtraChargesById(_id);
            ViewBag.ExtraCharge = extraCharge;
            return View("UpdateExtraCharges", blExtracharges.getListOfExtraCharges());
        }

        public ActionResult UpdateExtraCharges(ExtraCharge _extraCharge)
        {
            BLExtraCharges blExtracharges = new BLExtraCharges();
            blExtracharges.UpdateExtraCharges(_extraCharge);
            return RedirectToAction("DisplayAddExtraCharges");
        }
        #endregion

        #region Special Offer
        public ActionResult DisplayAddSpecialOffer()
        {
            BLSpecialOffer blspecialOffer = new BLSpecialOffer();
            return View("AddSpecialOffer", blspecialOffer.getListOfSpecialOffer());

        }
        public ActionResult addSpecialOffer(SpecialOffer _specialOffer)
        {
            BLSpecialOffer blspecialOffer = new BLSpecialOffer();
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~") + ProjectVaraiables.SERVERPATH + "\\" + file.FileName);
                    _specialOffer.Image = @"..\" + ProjectVaraiables.SERVERPATH + "\\" + file.FileName;

                }
                


            }

            blspecialOffer.addSpecialOffer(_specialOffer);
            return RedirectToAction("DisplayAddSpecialOffer");
        }

        public ActionResult deleteSpecialOffer(int _id)
        {
            BLSpecialOffer blspecialOffer = new BLSpecialOffer();
            blspecialOffer.deleteSpecialOffer(_id);
            return RedirectToAction("DisplayAddSpecialOffer");
        }
        public ActionResult displayUpdateSpecialOffer(int _id)
        {
            BLSpecialOffer blspecialOffer = new BLSpecialOffer();
            SpecialOffer specialOffer = blspecialOffer.getSpecialOfferById(_id);
            ViewBag.SpecialOffer = specialOffer;
            return View("UpdateSpecialOffer", blspecialOffer.getListOfSpecialOffer());
        }
        public ActionResult UpdateSpecialOffer(SpecialOffer _specialOffer)
        {
            string isChecked = Request.Form["ImgBox"];
            if (isChecked != null)
            {
                if (isChecked.Equals("on"))
                    _specialOffer.Image = string.Empty;
            }
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~") + ProjectVaraiables.SERVERPATH + "\\" + file.FileName);
                    _specialOffer.Image = @"..\" + ProjectVaraiables.SERVERPATH + "\\" + file.FileName;
                }
              


            }
            new BLSpecialOffer().UpdateSpecialOffer(_specialOffer);
            return RedirectToAction("DisplayAddSpecialOffer");
        }

        public ActionResult deleteSpecialOfferAddOn(int _Itemid,int _OfferId)
        {
            BLFood blfood = new BLFood();
            SpecialOffer_AddOn spoa = blfood.getListOfSpecialOffer_AddOn().FirstOrDefault(offer => offer.AddonID == _Itemid && offer.SpecialOfferID == _OfferId);
            return RedirectToAction("displaySpecialOfferPage", _OfferId);
        
        }

        public ActionResult deleteSpecialOfferItem(int _Itemid, int _OfferId)
        {
            BLFood blfood = new BLFood();
            SpecialOffer_Item spoa = blfood.getListOfSpecialOffer_Item().FirstOrDefault(offer => offer.CategoryId == _Itemid && offer.SpecialOfferID == _OfferId);
            return RedirectToAction("displaySpecialOfferPage", _OfferId);

        }

        public ActionResult addSpecialOfferItem(SpecialOffer_Item specialOffer_Item, string flexible)
        {
            specialOffer_Item.isFlexible = Convert.ToInt32(flexible);
            BLFood blfood = new BLFood();
            blfood.addSpecialOffer_Item(specialOffer_Item);
            return RedirectToAction("displaySpecialOfferPage", specialOffer_Item.SpecialOfferID);
        }



        public ActionResult displaySpecialOfferPage(int _id)
        {
            BLFood blfood = new BLFood();
            SpecialOffer so = blfood.getSpecialOffersById(_id);
            ViewBag.Sizes = blfood.getListOfFood_Sizes();
            ViewBag.Cousines = blfood.getListOfCousine();
            ViewBag.AddOn = blfood.getListOfSpecialOffer_AddOn().Where(offer => offer.SpecialOfferID == _id);
            ViewBag.Items = blfood.getListOfSpecialOffer_Item().Where(offer => offer.SpecialOfferID == _id);
            return View("SpecialOfferItem", so);
        }


        #endregion

    
    }
}

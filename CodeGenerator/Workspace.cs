using CodeGenerator.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    
    public static class Workspace
    {
        public static List<Generator> rules;
        public static Dictionary<string, string> inputsConfiguration;
        public static List<Entity> entities;

        public static void Initialize()
        {
            rules = new List<Generator>();
            //inputsConfiguration = new Dictionary<string, string>();
            inputsConfiguration =
              new Dictionary<string, string>(){
                                  {"VersionAngular", "Angular 15"},
                                  {"VersionNet", ".Net7"},
                                {"Directory", "c:777"},
                              {"Author","Edgardo" },
                              {"emailAuthor","Edgardo.anaya" },
                              {"Entity1","ICategory" },
                            {"Entity2","IAudit" },
                  {"{Entity.Field.Type}","stringEdg" },
                  {"{Entity.Field.Name}","EntityEdg" },
                  {"WorkspaceFolder","C:\\SWO\\CodeAccelerator\\Back-Net-Template\\" },
                  {"GenerationFolder","C:\\SWO\\CodeAccelerator\\Back-Net-Generation\\" }
              };

            entities = new List<Entity>();

            //Entity audit = new Entity("Audit");
            //audit.Fields.Add(new Field("Entity", "string", "null!"));
            //audit.Fields.Add(new Field("Operation", "string", "null!"));
            //audit.Fields.Add(new Field("NewRecord", "string", "null!"));
            //audit.Fields.Add(new Field("OldRecord", "string?", "null!"));
            //audit.Fields.Add(new Field("UrlSource", "string", "null!"));
            //audit.Fields.Add(new Field("Username", "string", "null!"));
            //audit.Fields.Add(new Field("IpAddress", "string", "null!"));
            //audit.Fields.Add(new Field("Application", "string?", ""));
            //audit.Fields.Add(new Field("AuditDate", "DateTime", ""));
            //entities.Add(audit);

            Entity category = new Entity("Category", "Name");
            category.Fields.Add(new Field("Name", "string", "null!","","","50",true));
            category.Fields.Add(new Field("InscriptionDate", "DateTime?", ""));
            category.Fields.Add(new Field("AppliesDiscount", "bool", ""));
            category.Fields.Add(new Field("Products", "List<Product>", "null!"));
            entities.Add(category);

            Entity city = new Entity("City", "Name");                       
            city.Fields.Add(new Field("StateLocationId", "int", "", "StateLocation","","",true));
            city.Fields.Add(new Field("StateLocation", "State", "", "", "[JsonIgnore]"));
            city.Fields.Add(new Field("Name", "string", "null!", "", "", "50",true));
            entities.Add(city);

            Entity customer = new Entity("Customer", "Name");
            customer.Fields.Add(new Field("Name", "string", "null!", "", "", "50", true));
            customer.Fields.Add(new Field("Email", "string", "null!", "", "", "100",true));
            customer.Fields.Add(new Field("RegistrationDate", "DateTime", "","","","",true));
            customer.Fields.Add(new Field("IsVip", "bool", "false!"));
            customer.Fields.Add(new Field("ShoppingCartId", "int", ""));
            customer.Fields.Add(new Field("ShoppingCart", "ShoppingCart", "null!"));
            customer.Fields.Add(new Field("ShippingAddressId", "int?", "", "ShippingAddress"));
            customer.Fields.Add(new Field("ShippingAddress", "ShippingAddress?", "null!","", "[JsonIgnore]"));
            entities.Add(customer);

            Entity product = new Entity("Product", "Name");
            product.Fields.Add(new Field("Name", "string", "null!", "", "", "50", true));
            product.Fields.Add(new Field("Description", "string", "null!", "", "", "100"));
            product.Fields.Add(new Field("Price", "decimal", "0!","","","",true, "10,2"));
            product.Fields.Add(new Field("UnitStock", "int", "0!", "", "", "", true));
            product.Fields.Add(new Field("Categories", "List<Category>", "null!"));            
            entities.Add(product);

            Entity shippingAddress = new Entity("ShippingAddress", "Name");
            shippingAddress.Fields.Add(new Field("Name", "string", "null!", "", "", "50", true));
            shippingAddress.Fields.Add(new Field("Address", "string", "null!", "", "", "100", true));
            shippingAddress.Fields.Add(new Field("CustomerId", "int", "", "Customer", "","",true));
            shippingAddress.Fields.Add(new Field("Customer", "Customer", "null!","", "[JsonIgnore]"));
            shippingAddress.Fields.Add(new Field("CityId", "int", "", "City", "", "", true));
            shippingAddress.Fields.Add(new Field("City", "City", "null!", "", "[JsonIgnore]"));            
            entities.Add(shippingAddress);

            Entity shoppingCart = new Entity("ShoppingCart", "CustomerId");
            shoppingCart.Fields.Add(new Field("CustomerId", "int", "", "Customer", "","", true));
            shoppingCart.Fields.Add(new Field("Customer", "Customer", "null!", "", "[JsonIgnore]"));
            shoppingCart.Fields.Add(new Field("TotalPrice", "decimal", "0!", "", "", "", true, "10,2"));
            shoppingCart.Fields.Add(new Field("Items", "List<ShoppingCartItem>", "new List<ShoppingCartItem>()"));
            entities.Add(shoppingCart);

            Entity shoppingCartItem = new Entity("ShoppingCartItem", "Price");
            shoppingCartItem.Fields.Add(new Field("ProductId", "int", "", "Product"));
            shoppingCartItem.Fields.Add(new Field("Product", "Product", "null!", "", "[JsonIgnore]"));
            shoppingCartItem.Fields.Add(new Field("Quantity", "int", "0!"));
            shoppingCartItem.Fields.Add(new Field("Price", "decimal", "0!"));
            shoppingCartItem.Fields.Add(new Field("Discount", "decimal", "0!"));
            shoppingCartItem.Fields.Add(new Field("ShoppingCartId", "int", "", "ShoppingCart"));
            shoppingCartItem.Fields.Add(new Field("ShoppingCart", "ShoppingCart", "null!", "", "[JsonIgnore]"));
            entities.Add(shoppingCartItem);

            Entity state = new Entity("State","Name");
            state.Fields.Add(new Field("Name", "string", "null!", "", "", "50"));
            entities.Add(state);

        }

        public static void AddRule(Generator rule)
        {
            rules.Add(rule);
        }

        public static void AddEntity(Entity entity)
        {
            entities.Add(entity);
        }

        public static void AddInputConfiguration(string key, string value)
        {
            inputsConfiguration.Add(key, value);
        }

        public static void DeleteRule(Generator rule)
        {
            rules.Remove(rule);
        }

        public static void DeleteEntity(Entity entity)
        {
            entities.Remove(entity);
        }

        public static void DeleteInputConfiguration(string key)
        {
            inputsConfiguration.Remove(key);
        }

        //public static RulesEngine GetRule(string name)
        //{
        //    foreach (RulesEngine rule in rules)
        //    {
        //        if (rule.Name.ToUpper() == name.ToUpper())
        //        {
        //            return rule;
        //        }
        //    }
        //    return null;
        //}

        public static Entity GetEntity(string name)
        {
            foreach (Entity entity in entities)
            {
                if (entity.Name.ToUpper() == name.ToUpper())
                {
                    return entity;
                }
            }
            return null;
        }

        public static string GetInputConfiguration(string key)
        {
            return inputsConfiguration[key];
        }

        public static void Clear()
        {
            rules.Clear();
            inputsConfiguration.Clear();
            entities.Clear();
        }
    }   
    
}

using Microsoft.AspNetCore.Http.HttpResults;
using SudApi.Migrations;

namespace SudApi.Models
{
    public class FarmerDetailsSqlDAL : IFarmer
    {
        private MvcDbContext dc;

        public FarmerDetailsSqlDAL(MvcDbContext dc)
        {
            this.dc = dc;
        }

        public List<Farmer> Farmers_Select()
        {
            var FarmAds = dc.Farmers.ToList();
            return FarmAds;
        }

        public List<Farmer> Farmer_Select_District(string District)
        {
            var FarmAds = dc.Farmers.Where(f => f.District == District).ToList();
            return FarmAds;
        }

        public int Farmer_Select_By_Guid(string guid)
        {
            var FarmAds = dc.Farmers.Where(f => f.UserGuid == guid).ToList().Count;
            return FarmAds;
        }

        public Farmer Farmer_Select(int Custid)
        {
            var FarmAd = dc.Farmers.Find(Custid);
            return FarmAd;
        }

        public void Farmer_Insert(Farmer F)
        {
            dc.Farmers.Add(F);
            dc.SaveChanges();
        }

        public void Farmer_Update(Farmer F)
        {
            var UpdatedAd = dc.Farmers.Find(F.Custid);
            if(UpdatedAd != null)
            {
                UpdatedAd.Name = F.Name;
                UpdatedAd.FirstBreed = F.FirstBreed;
                UpdatedAd.FB_Price = F.FB_Price;
                UpdatedAd.FB_Pieces = F.FB_Pieces;
                UpdatedAd.SecondBreed = F.SecondBreed;
                UpdatedAd.SB_Price = F.SB_Price;
                UpdatedAd.SB_Pieces = F.SB_Pieces;
                UpdatedAd.ThirdBreed = F.ThirdBreed;
                UpdatedAd.TB_Price = F.TB_Price;
                UpdatedAd.TB_Pieces = F.TB_Pieces;
                UpdatedAd.Address = F.Address;
                UpdatedAd.District = F.District;
                UpdatedAd.ImagePath = F.ImagePath;
                UpdatedAd.UserGuid = F.UserGuid;

                dc.SaveChanges();
            }
        }

        public void Farmer_Delete(int Custid)
        {
            var DeletedAd = dc.Farmers.Find(Custid);
            if (DeletedAd == null)
            {
                throw new Exception("Product could not be found or already deleted.");
            }
            else
            {
                dc.Farmers.Remove(DeletedAd);
                dc.SaveChanges();
            }
        }
    }
}

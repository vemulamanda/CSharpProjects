namespace SudApi.Models
{
    public interface IFarmer
    {
        List<Farmer> Farmers_Select();
        List<Farmer> Farmer_Select_District(string district);
        int Farmer_Select_By_Guid(string userguid);
        Farmer Farmer_Select(int Custid);
        void Farmer_Insert(Farmer F);
        void Farmer_Update(Farmer F);
        void Farmer_Delete(int Custid);
        //List<Farmer> EditAllFarmers(string userid);
    }
}

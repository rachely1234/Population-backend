using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IPopulation
    {
        Task<bool> AddCity(string cityName);
        Task<List<Population>> Getallpopulations(int skip);

        Task<bool> DeletePopulation(int id);
        Task<bool> EditPopulation(int src ,string destination);
        Task <List<Population>> GetPopulationByPartOfName(string name,int skip);
        Task<List<Population>> SortInAscendingOrder(int skip);
        Task<List<Population>> SortInDescendingOrder(int skip); 
       

    }
}

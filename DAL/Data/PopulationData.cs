using DAL.Interface;
using Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Dtos;
using System.Globalization;





namespace DAL.Data
{
    public class PopulationData:IPopulation
    {
        private readonly IMapper _mapper;
        private readonly ProjectCotext _context;
    

        public PopulationData(ProjectCotext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
    

        public async Task<bool> AddCity(string cityName)
        {
            var population = new Population
            {
                Name = cityName 
            };

            var PopulationFromModel = _mapper.Map<Population>(population);
            _context.Add(PopulationFromModel);
            var isOk = _context.SaveChanges() >= 0;
            return isOk;
        }



        public async Task<bool> DeletePopulation(int id)
        {
            try
            {
                var population = new Population { Id = id }; 
                _context.Attach(population);
                _context.Entry(population).State = EntityState.Deleted;
                var isOk = await _context.SaveChangesAsync();
                return isOk > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> EditPopulation(int src,string destination)
        {
            try
            {
                var Population1 = await _context.Populations.FirstOrDefaultAsync(p=>p.Id==src);
                Console.WriteLine(Population1);
                Population1.Name = destination;
                
                int isOk = await _context.SaveChangesAsync();

 
                return isOk>0;  
                
                

               
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public async Task<List<Population>> Getallpopulations(int skip)
        {

            try
            {
                var population = await _context.Populations.Skip(skip*5)
            .Take(5).ToListAsync();
                return population;
            }
            catch (Exception ex)
            {
                
                return null;
            }

        }

        public async Task<List<Population>> GetPopulationByPartOfName(string name ,int skip)
        {

            try
            {
               var populations = await _context.Populations
            .Where(p => p.Name .StartsWith(name)).Skip(skip*5)
            .Take(5)
            .ToListAsync();

                return populations;

                
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public Task<Population> SearchSettlementsByHebrewWEbsinit(string name)
        {
            throw new NotImplementedException();
        }

        
       
        public async Task<List<Population>> SortInAscendingOrder(int skip)
        {
          
            try
            {


                var populations = await _context.Populations.ToListAsync();

                var sortedPopulations = populations
            .OrderBy(p => p.Name, StringComparer.Create(new CultureInfo("he-IL"), true)).Skip(skip*5).Take(5)
            .ToList();


                return sortedPopulations;

            }
            catch (Exception ex)
            {

                return null;
            }

        }
        
        public async Task<List<Population>> SortInDescendingOrder(int skip)
        {
            


            try
            {
               
                var populations = await _context.Populations.ToListAsync();

                var sortedPopulations = populations
            .OrderByDescending(p => p.Name, StringComparer.Create(new CultureInfo("he-IL"), true)).Skip(skip*5).Take(5)  
            .ToList();


                return sortedPopulations;


            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}

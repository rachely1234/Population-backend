using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Data;
using DAL.Dtos;
using Models.Model;


namespace DAL.profile
{
    public class profile : Profile
    {

        public profile()
        {
            
        
            CreateMap<PopulationDto, Population>();


        }

    }
}

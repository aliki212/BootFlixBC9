using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootFlixBC9.Models;
using BootFlixBC9.DTOs;

namespace BootFlixBC9.App_Start
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Viewer, ViewerDto>();
            CreateMap<ViewerDto, Viewer>();
            CreateMap<Serie, SerieDto>();
            CreateMap<SerieDto, Serie>();
            CreateMap<MembershipType, MembershipTypeDto>();
            //CreateMap<MembershipTypeDto, MembershipType>();
            CreateMap<Genre, GenreDto>();
        }
    }
}
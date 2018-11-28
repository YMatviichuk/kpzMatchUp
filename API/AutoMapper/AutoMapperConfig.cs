using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Dtos;
using API.Models;
using AutoMapper;
using AutoMapper.Configuration;

namespace API.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<PlayerSave, SaveHeadDto>()
                    .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.Player.PlayerName));

            });
        }
    }
}
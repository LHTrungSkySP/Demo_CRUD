﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapping
{
    internal interface IMapTo<T>
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(GetType(), typeof(T)).ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) =>
                {
                    return srcMember != null;
                });
            });
        }
    }
}

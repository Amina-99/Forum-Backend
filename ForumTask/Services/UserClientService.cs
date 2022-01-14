using AutoMapper;
using ForumTask.Data;
using ForumTask.Models;
using ForumTask.Models.DTOs;
using ForumTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ForumTask.Services
{
    public class UserClientService : IUserClientService
    {
        private readonly HttpClient httpClient;
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;
        public UserClientService(IMapper mapper, IServiceScopeFactory scopeFactory)
        {
            httpClient = new HttpClient()
            {

                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
            };
            _mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        public async Task GetUsers()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                var userCount = await context.User.CountAsync();
                if (userCount == 0)
                {
                    var url = string.Format("users");
                    var result = new List<UserDTO>();
                    var response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        result = JsonSerializer.Deserialize<List<UserDTO>>(stringResponse, new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                        var mappedUsers = _mapper.Map<List<UserDTO>, List<User>>(result);
                        await context.User.AddRangeAsync(mappedUsers);
                        await context.SaveChangesAsync();
                    }

                    else
                    {
                        throw new HttpRequestException(response.ReasonPhrase);
                    }
                }
            }
        }

      
    }
}


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
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ForumTask.Services
{
    public class PostClientService : IPostClientService
    {
        private readonly HttpClient httpClient;
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;
        public PostClientService(IMapper mapper, IServiceScopeFactory scopeFactory)
        {
            httpClient = new HttpClient()
            {

                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
            };
           
            _mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        public async Task GetPosts()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                var postsCount = await context.Post.CountAsync();
                if (postsCount == 0)
                {
                    var url = string.Format("posts");
                    var result = new List<PostDTO>();
                    var response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        result = JsonSerializer.Deserialize<List<PostDTO>>(stringResponse, new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                        var postsList = _mapper.Map<List<PostDTO>, List<Post>>(result);
                        await context.Post.AddRangeAsync(postsList);
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

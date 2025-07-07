using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using Bigon.İnfrastructure.Services.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogPostModule.Commands.BlogPostAddCommand
{
    internal class BlogPostAddRequestHandler : IRequestHandler<BlogPostAddRequest, BlogPost>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IFileService fileService;

        public BlogPostAddRequestHandler(IBlogPostRepository blogPostRepository,IFileService fileService)
        {
            this.blogPostRepository = blogPostRepository;
            this.fileService = fileService;
        }
        public async Task<BlogPost> Handle(BlogPostAddRequest request, CancellationToken cancellationToken)
        {
            var model = new BlogPost
            {
                Title = request.Title,
                Body = request.Body,
                CategoryId = request.CategoryId
            };
            model.ImagePath = fileService.Upload(request.File);
            model.Slug = request.Title;
            blogPostRepository.Add(model);
            blogPostRepository.Save();
            return model;
        }
    }
}

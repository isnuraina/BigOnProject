using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogPostModule.Queries.BlogPostGetAllQuery
{
    internal class BlogPostGetAllRequestHandler : IRequestHandler<BlogPostGetAllRequest, IEnumerable<BlogPost>>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ICategoryRepository categoryRepository;

        public BlogPostGetAllRequestHandler(IBlogPostRepository blogPostRepository,ICategoryRepository categoryRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.categoryRepository = categoryRepository;
        }
        //public async Task<IEnumerable<BlogPostGetAllDto>> Handle(BlogPostGetAllRequest request, CancellationToken cancellationToken)
        //{
        //    var data = await blogPostRepository.GetAll(m => m.DeletedBy == null).ToListAsync(cancellationToken);
            //var data = await blogPostRepository
            //    .GetAll(m => m.DeletedBy == null)
            //    .Select()
            //    .ToListAsync(cancellationToken);
            //var data = await (from bp in blogPostRepository.GetAll(m => m.DeletedBy == null)
            //            join c in categoryRepository.GetAll() on bp.CategoryId equals c.Id
            //            select new BlogPostGetAllDto
            //            {
            //                Id = bp.Id,
            //                Title = bp.Title,
            //                Slug = bp.Slug,
            //                Body = bp.Body,
            //                PublishedAt = bp.PublishedAt,
            //                CategoryId = bp.CategoryId,
            //                CategoryName = c.Name
            //            }).ToListAsync(cancellationToken);
        //    return data;
        //}

        async Task<IEnumerable<BlogPost>> IRequestHandler<BlogPostGetAllRequest, IEnumerable<BlogPost>>.Handle(BlogPostGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = await blogPostRepository.GetAll(m => m.DeletedBy == null).ToListAsync(cancellationToken);
            return data;
        }
        //public async Task<IEnumerable<BlogPostGetAllDto>> Handle(BlogPostGetAllRequest request, CancellationToken cancellationToken)
        //{
        //    var data = await (from bp in blogPostRepository.GetAll(m => m.DeletedBy == null)
        //                      join c in categoryRepository.GetAll() on bp.CategoryId equals c.Id
        //                      select new BlogPostGetAllDto
        //                      {
        //                          Id = bp.Id,
        //                          Title = bp.Title,
        //                          Slug = bp.Slug,
        //                          ImagePath = bp.ImagePath,
        //                          Body = bp.Body,
        //                          PublishedAt = bp.PublishedAt,
        //                          CategoryId = bp.CategoryId,
        //                          CategoryName = c.Name
        //                      }).ToListAsync(cancellationToken);
        //    return data;
        //}
    }
}

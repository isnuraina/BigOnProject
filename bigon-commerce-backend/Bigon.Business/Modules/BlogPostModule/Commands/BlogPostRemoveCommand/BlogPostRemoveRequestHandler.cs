﻿using Bigon.İnfrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BlogPostModule.Commands.BlogPostRemoveCommand
{
    //internal class BlogPostRemoveRequestHandler : IRequestHandler<BlogPostRemoveRequest>
    //{
    //    private readonly IBlogPostRepository  blogPostRepository;

    //    public BlogPostRemoveRequestHandler(IBlogPostRepository blogPostRepository)
    //    {
    //        this.blogPostRepository = blogPostRepository;
    //    }
        //public async Task<Unit> Handle(BlogPostRemoveRequest request, CancellationToken cancellationToken)
        //{
        //    var model = blogPostRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);
        //    blogPostRepository.Remove(model);
        //    blogPostRepository.Save();
        //}
    //}
}

﻿using jCoreDemoApp.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace jCoreDemoApp.Application.ContactLists.Commands.CreateContactList
{
    public class CreateContactListCommandValidator : AbstractValidator<CreateContactListCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateContactListCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.ContactLists
                .AllAsync(l => l.Title != title);
        }
    }
}

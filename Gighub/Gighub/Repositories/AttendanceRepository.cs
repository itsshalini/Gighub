﻿using Gighub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gighub.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
              .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
              .ToList();
        }

        public IEnumerable<Attendance> GetAttendance(int id, string userId)
        {
            return _context.Attendances
                      .Where(a => a.GigId == id && a.AttendeeId == userId);
        }
    }
}
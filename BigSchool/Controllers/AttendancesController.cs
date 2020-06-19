﻿using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
            {
                var attendance = new Attendance
                {
                    CourseId = attendanceDto.CourseId,
                    AttendeeId = userId
                };
                _dbContext.Attendances.Attach(attendance);
                _dbContext.Attendances.Remove(attendance);
                _dbContext.SaveChanges();

                return Ok();
            }
            else {
                var attendance = new Attendance
                {
                    CourseId = attendanceDto.CourseId,
                    AttendeeId = userId
                };
                _dbContext.Attendances.Add(attendance);
                _dbContext.SaveChanges();

                return Ok();
            }
            
        }
    }
}

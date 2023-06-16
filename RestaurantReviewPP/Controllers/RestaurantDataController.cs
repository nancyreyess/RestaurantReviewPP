using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestaurantReviewPP.Models;

namespace RestaurantReviewPP.Controllers
{
    public class RestaurantDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RestaurantData/ListRestaurants
        [HttpGet]
        public IQueryable<Restaurant> ListRestaurants()
        {
            return db.Restaurants;
        }

        // GET: api/RestaurantData/FindRestaurant/5
        [ResponseType(typeof(Restaurant))]
        [HttpGet]
        public IHttpActionResult FindRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // POST: api/RestaurantData/UpdateRestaurant/5
        // post when you want ned data manipulation language, and get when you just need to read
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.RestaurantId)
            {
                return BadRequest();
            }

            db.Entry(restaurant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RestaurantData/AddRestaurant
        [ResponseType(typeof(Restaurant))]
        [HttpPost]
        public IHttpActionResult AddRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurants.Add(restaurant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restaurant.RestaurantId }, restaurant);
        }

        // POST: api/RestaurantData/DeleteRestaurant/5
        [ResponseType(typeof(Restaurant))]
        [HttpPost]
        public IHttpActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            db.Restaurants.Remove(restaurant);
            db.SaveChanges();

            return Ok(restaurant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantExists(int id)
        {
            return db.Restaurants.Count(e => e.RestaurantId == id) > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using RealState.Manager;
using RealState.Models;

namespace RealState.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertyController : ApiController
    {
        // GET: api/Property
        private readonly RealStateEntities _aRealStateEntities = new RealStateEntities();
        private HttpResponseMessage _response;
        /// <summary>
        /// Get all Property
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try 
            {
                var result = _aRealStateEntities.vProperties.Where(w=>w.Purpose==1).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get Property by Area Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetPropertyByArea(int? id)
        {
            try 
            {
                var result = _aRealStateEntities.vProperties.Where(w => w.Area == id && w.Purpose == 1).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get Property by Sub PropertyType
        /// </summary>
        /// <param name="id">Sub PropertyType Id</param>
        /// <returns></returns>
        public HttpResponseMessage GetPropertyBySubPropertyType(int? id)
        {
            try 
            {
                var result = _aRealStateEntities.vProperties.Where(w => w.SubPropertyType == id && w.Purpose == 1).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// Get Property by type and area id
        /// </summary>
        /// <param name="typeId">Sub property Id</param>
        /// <param name="areaId">Area id</param>
        /// <returns></returns>
        public HttpResponseMessage GetPropertyBySubPropertyTypeArea(int? typeId,int? areaId)
        {
            try 
            {
                var result = _aRealStateEntities.vProperties.Where(w => w.SubPropertyType == typeId && w.Area == areaId && w.Purpose == 1).ToList();
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetPropertyByMinArea(int? id)
        {
            try
            {
                var result = _aRealStateEntities.vProperties.Where(w => w.Area == id && w.Purpose == 1).ToList().OrderBy(x => x.SalePrice);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetPropertyByMaxArea(int? id)
        {
            try
            {
                var result = _aRealStateEntities.vProperties.Where(w => w.Area == id && w.Purpose == 1).ToList()
                    .OrderByDescending(x => x.SalePrice);
                _response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.NotFound, e);
            }
            return _response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aProperty"></param>
        /// <param name="coverPhoto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PostProperty()
        {
            var request = HttpContext.Current.Request;
            
            try
            {
                Property aProperty = new Property()
                {
                    OwnerId = Convert.ToInt32(request.Form["OwnerId"]),
                    PropertyName = request.Form["PropertyName"],
                    Area = Convert.ToInt32(request.Form["Area"]),
                    Address = request.Form["Address"],
                    Longitude = request.Form["Longitude"],
                    Latitude = request.Form["Latitude"],
                    SalePrice = Convert.ToInt32(request.Form["SalePrice"]),
                    SubPropertyType = Convert.ToInt32(request.Form["SubPropertyType"]),
                    BedRoom = Convert.ToInt32(request.Form["BedRoom"]),
                    WashRoom = Convert.ToInt32(request.Form["WashRoom"]),
                    Varanda = Convert.ToInt32(request.Form["Varanda"]),
                    DrawingRoom = Convert.ToBoolean(request.Form["DrawingRoom"]),
                    Parking = Convert.ToBoolean(request.Form["Parking"]),
                    FlatSize = Convert.ToInt32(request.Form["FlatSize"]),
                    BulidingYear = Convert.ToInt32(request.Form["BulidingYear"]),
                    FloorLevel = Convert.ToInt32(request.Form["FloorLevel"]),
                    Preference = request.Form["Preference"],
                    Purpose = Convert.ToInt32(request.Form["Purpose"]),
                    PublishDate = DateTime.Now,
                    Status = 1
                };
                var coverPhoto = request.Files["CoverPhoto"];
                if (coverPhoto != null)
                    aProperty.CoverUrl = Common.SaveImage(coverPhoto);
                var saveProperty = _aRealStateEntities.Properties.Add(aProperty);
                _aRealStateEntities.SaveChanges();
                _response = Request.CreateResponse(HttpStatusCode.OK, saveProperty);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
            return _response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PostPropertyPhotos()
        {
            var request = HttpContext.Current.Request;
            
            try
            {
                List<PropertyFile> aPropertyFiles = new List<PropertyFile>();
                
                var photo1 = request.Files["photo1"];
                var photo2 = request.Files["photo2"];
                var photo3 = request.Files["photo3"];
                var propertyId = Convert.ToInt32(request.Form["propertyId"]);
                var details1 = request.Form["details1"];
                var details2 = request.Form["details2"];
                var details3 = request.Form["details3"];
                if (photo1 != null)
                    aPropertyFiles.Add(BuildPropertyFile(propertyId,details1,photo1));
                if (photo2 != null)
                    aPropertyFiles.Add(BuildPropertyFile(propertyId,details2, photo2));
                if (photo3 != null)
                    aPropertyFiles.Add(BuildPropertyFile(propertyId,details3, photo3));
                var saveProperty = _aRealStateEntities.PropertyFiles.AddRange(aPropertyFiles);
                _aRealStateEntities.SaveChanges();
                _response = Request.CreateResponse(HttpStatusCode.OK, saveProperty);
            }
            catch (Exception e)
            {
                _response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
            return _response;
        }

        private PropertyFile BuildPropertyFile(int propertyId,string details,HttpPostedFile photoFile)
        {
            return new PropertyFile
            {
                PropertyId = propertyId, Details = details, FilePath = Common.SaveImage(photoFile)
            };
        }
    }
}

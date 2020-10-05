using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Covid19RS.Models;
using System.Net.Http;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace Covid19RS.Controllers
{
    public class Covid19Controller : Controller
    {
        private readonly Covid19RSContext _context;

        public Covid19Controller(Covid19RSContext context)
        {
            _context = context;
        }

        // GET: Covid19
        public async Task<IActionResult> Index()
        {
            ////test za polovne automobile
            //HttpClient client = new HttpClient();
            //var response = await client.GetAsync("https://www.polovniautomobili.com/auto-oglasi/pretraga?page=2&sort=basic&price_to=4300&year_from=2008&city_distance=0&showOldNew=all&without_price=1&mileage_to=150000&gearbox%5B0%5D=251");
            //var pageContents = await response.Content.ReadAsStringAsync();

            //HtmlDocument pageDocument = new HtmlDocument();
            //pageDocument.LoadHtml(pageContents);

            //var listNazivModela = pageDocument.DocumentNode.SelectNodes("//*//div/article/h2/span//a").Select(t => t.InnerText).ToList();
            //var listOpisModela = pageDocument.DocumentNode.SelectNodes("//*//div/article/div/div/div/div/div/div//div").Select(t => t.InnerText).ToList();
            //var listCenaModela = pageDocument.DocumentNode.SelectNodes("//*//div/article/h2/span//span").Select(t => t.InnerText).ToList();
            //var listSlikaModela = pageDocument.DocumentNode.SelectNodes("//*//div/article/div/div/a/figure//img").Select(t => t.Attributes["src"].Value).ToList();

            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://covid19.rs/");
            var pageContents = await response.Content.ReadAsStringAsync();

            HtmlDocument pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(pageContents);

            var listCovid19Serbia = pageDocument.DocumentNode.SelectNodes("(//div[contains(@class,'elementor-widget-container')]//p)").Select(t => t.InnerText).ToList();

            return View(listCovid19Serbia);
        }

        // GET: Covid19/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covid19 = await _context.Covid19
                .FirstOrDefaultAsync(m => m.Id == id);
            if (covid19 == null)
            {
                return NotFound();
            }

            return View(covid19);
        }

        // GET: Covid19/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Covid19/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UkupanBrRegSlucajeva,BrojSmrtnihSlucajeva,ProcenatSmrtnosti,BrojTestiranihOsoba,BrojTestiranihOsoba24h,BrojPotvrdjenihSlucajeva24h,BrojPreminulihosoba24h,BrojAktivnihSlucajeva,BrojOsobaNaRespiratorima")] Covid19 covid19)
        {
            if (ModelState.IsValid)
            {
                _context.Add(covid19);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(covid19);
        }

        // GET: Covid19/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covid19 = await _context.Covid19.FindAsync(id);
            if (covid19 == null)
            {
                return NotFound();
            }
            return View(covid19);
        }

        // POST: Covid19/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UkupanBrRegSlucajeva,BrojSmrtnihSlucajeva,ProcenatSmrtnosti,BrojTestiranihOsoba,BrojTestiranihOsoba24h,BrojPotvrdjenihSlucajeva24h,BrojPreminulihosoba24h,BrojAktivnihSlucajeva,BrojOsobaNaRespiratorima")] Covid19 covid19)
        {
            if (id != covid19.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(covid19);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Covid19Exists(covid19.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(covid19);
        }

        // GET: Covid19/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covid19 = await _context.Covid19
                .FirstOrDefaultAsync(m => m.Id == id);
            if (covid19 == null)
            {
                return NotFound();
            }

            return View(covid19);
        }

        // POST: Covid19/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var covid19 = await _context.Covid19.FindAsync(id);
            _context.Covid19.Remove(covid19);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Covid19Exists(int id)
        {
            return _context.Covid19.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> Global()
        {
            Rootobject countries = new Rootobject();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://api.covid19api.com/summary");
            var pageContents = await response.Content.ReadAsStringAsync();

            countries = JsonConvert.DeserializeObject<Rootobject>(pageContents);

            return View(countries);
        }
    }
}

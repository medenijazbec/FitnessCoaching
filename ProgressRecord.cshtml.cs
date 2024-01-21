using Fitness.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;

namespace Fitness.Pages
{
    public class ProgressRecordModel : PageModel
    {
        [BindProperty]
        public ProgressRecord NewProgressRecord { get; set; }
        [BindProperty]
        public string MeasurementKey { get; set; }
        [BindProperty]
        public double MeasurementValue { get; set; }

        [TempData]
        public string SerializedProgressRecord { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(SerializedProgressRecord))
            {
                NewProgressRecord = JsonConvert.DeserializeObject<ProgressRecord>(SerializedProgressRecord);
            }
            else
            {
                NewProgressRecord = new ProgressRecord(DateTime.Now, string.Empty);
            }
        }

        public IActionResult OnPost(DateTime date, string notes, string measurementKey, double measurementValue)
        {
            if (string.IsNullOrEmpty(SerializedProgressRecord))
            {
                NewProgressRecord = new ProgressRecord(date, notes);
            }
            else
            {
                NewProgressRecord = JsonConvert.DeserializeObject<ProgressRecord>(SerializedProgressRecord);
            }

            NewProgressRecord.AddMeasurement(measurementKey, measurementValue);

            SerializedProgressRecord = JsonConvert.SerializeObject(NewProgressRecord);

            return RedirectToPage();
        }
    }
}


/*
using Fitness.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Fitness.Pages
{
    public class ProgressRecordModel : PageModel
    {
        public ProgressRecord NewProgressRecord { get; set; }
        public string MeasurementKey { get; set; }
        public double MeasurementValue { get; set; }

        public void OnPost(DateTime date, string notes, string measurementKey, double measurementValue)
        {
            NewProgressRecord = new ProgressRecord(date, notes);
            NewProgressRecord.AddMeasurement(measurementKey, measurementValue);
        }
    }
}
*/
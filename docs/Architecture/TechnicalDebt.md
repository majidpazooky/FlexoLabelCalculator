# FlexoCalc Technical Debt

این فایل تمام مواردی را ثبت می‌کند که عمداً در فاز اول توسعه (Feature Complete)
به صورت ساده پیاده‌سازی شده‌اند و در فاز Refactor باید اصلاح شوند.

---

## TD-001
موضوع:
استفاده مستقیم از LayoutBuilder داخل LayoutGenerator

وضعیت:
بعداً با Dependency Injection جایگزین شود.

اولویت:
High

---

## TD-002

موضوع:
PaperWidthGenerator هنوز Brute Force است.

وضعیت:
بعداً فقط عرض‌های منطقی تولید شوند.

اولویت:
Critical

---

## TD-003

موضوع:
RankingEngine هنوز Weight قابل تنظیم ندارد.

وضعیت:
نسخه Enterprise

اولویت:
Medium

---

## TD-004

موضوع:
Schematic فقط Text خواهد بود.

وضعیت:
بعداً SVG و PDF Renderer اضافه شود.

اولویت:
Medium

---

## TD-005

موضوع:
هنوز Parallel Processing وجود ندارد.

وضعیت:
بعداً Parallel.ForEach

اولویت:
High

---

## TD-006

موضوع:
Caching برای Machine Profiles و Gearها

وضعیت:
نسخه Enterprise

اولویت:
Low

---

## TD-007

موضوع:
Shrink Suggestion باید Rule Based شود.

وضعیت:
بعداً Engine جداگانه

اولویت:
Medium

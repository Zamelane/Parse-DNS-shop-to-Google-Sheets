using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSparse
{
    public class laptop
    {
        // Laptops \ Specs
        public string? title;                    // Название
        public string? url;                      // Ссылка
        public double? price;                    // Цена
        // Meta
        public double? META_min_price;           // Минимальная цена
        public int?    META_count_start;         // Количество оценок
        public double? META_web_mark;            // Средняя оценка
        public string? META_warranty;            // Гарантия
        public string? META_diagonal;            // Размер экрана
        public string? META_weight;              // Вес
        // CPU
        public string? CPU_name_CPU;             // Название
        public string? CPU_consumption;          // Потребление
        public int?    CPU_support;              // Поддержка
        public int?    CPU_score;                // Баллы
        // RAM
        public string? RAM_frequency;            // Частота
        public bool?   RAM_expandable;           // Расширяемая
        public int?    RAM_volume;               // Объём
        public int?    RAM_score;                // Баллы
        // iGPU
        public string? iGPU_name;                // Название
        public string? iGPU_score;               // Баллы
        public int?    iGPU_support;             // Поддержка
        // GPU
        public string? GPU_name;                 // Название
        public int?    GPU_vram;                 // VRAM
        public int?    GPU_consumption;          // Потребление
        public int?    GPU_score;                // Баллы
        public int?    GPU_support;              // Поддержка
        // PWR
        public int?    PWR_container;            // Ёмкость аккумулятора
        public int?    PWR_power;                // Мощность БП
        public int?    PWR_autonomy;             // Автономность
        // SSD
        public string? SSD_interface;            // Интерфейс
        public int?    SSD_volume;               // Объём
        // DSP
        public bool?   DSP_matt;                 // Матовый
        public double? DSP_width;                // Ширина
        public double? DSP_height;               // Высота
        public int?    DSP_frequency;            // Частота
        public string? DSP_matrix;               // Матрица
        public int?    DSP_srgb;                 // sRGB гамма
        // unGRP
        public string? unGRP_adaptive_sync;      // Adaptive-Sync
        public string? unGRP_ports;              // Порты монитора
        public string? unGRP_usb4_tb4;           // USB4/TB4
        public int?    unGRP_lan;                // Порт LAN
        public bool?   unGRP_lighting;           // Подсветка
        public string? unGRP_version_wifi;       // версия WiFi
        public string? unGRP_OS;                 // OS

        public laptop() { }
    }
}

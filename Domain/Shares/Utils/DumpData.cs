using Domain.Entities;
using Domain.Shares.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Utils
{
    public class DumpData
    {
        private const int AVERAGE_SPEED_KM_PER_HOUR = 36;
        private static void CaculateDuration(in List<Domain.Entities.Route> routes)
        {
            var meter_per_second = AVERAGE_SPEED_KM_PER_HOUR / 3.6;

            routes.ForEach(route =>
            {
                double totalDuration = 0;
                double totalDistance = 0;

                route.Steps.ForEach(step =>
                {
                    var duration = step.Distance / meter_per_second;
                    step.Duration = duration;
                    totalDuration += duration;
                    totalDistance += step.Distance;
                });

                route.Distance = totalDistance;
                route.Duration = totalDuration;
            });
        }
        public static List<Station> DumpStations()
        {
            return new List<Station>
            {
                new Station
                {
                    Id = 1,
                    Longitude = 106.81402589177823,
                    Latitude = 10.879650683124561,
                    Name = "Ga Metro Bến Xe Suối Tiên",
                    Address = "80 Xa lộ Hà Nội, Bình An, Dĩ An, Bình Dương"
                },
                new Station
                {
                    Id = 2,
                    Longitude = 106.80126112015681,
                    Latitude = 10.8664854431366,
                    Name = "Ga Metro Đại học Quốc Gia",
                    Address = "39708 Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 3,
                    Longitude = 106.78884645537156,
                    Latitude = 10.85917304306453,
                    Name = "Ga Metro Công Viên Công Nghệ Cao",
                    Address = "4/16B Xa lộ Hà Nội, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 4,
                    Longitude = 106.77154946668446,
                    Latitude = 10.846402468851362,
                    Name = "Ga Metro Thủ Đức",
                    Address = "RQWC+GJX Xa lộ Hà Nội, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 5,
                    Longitude = 106.75836408336727,
                    Latitude = 10.821402021794112,
                    Name = "Ga Metro Phước Long",
                    Address = "88 Nguyễn Văn Bá, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 6,
                    Longitude = 106.75523952123311,
                    Latitude = 10.808505238748038,
                    Name = "Ga Metro Gạch Chiếc",
                    Address = "RQ54+93V Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 7,
                    Longitude = 106.74223332879555,
                    Latitude = 10.80225421782069,
                    Name = "Ga Metro An Phú",
                    Address = "RP2R+VV9 Xa lộ Hà Nội, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 8,
                    Longitude = 106.73370791313042,
                    Latitude = 10.800728306627473,
                    Name = "Ga Metro Thảo Điền",
                    Address = "763J Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 9,
                    Longitude = 106.72327125155881,
                    Latitude = 10.798621063183687,
                    Name = "Ga Metro Tân Cảng",
                    Address = "QPXF+C8J Nguyễn Hữu Cảnh, 25, Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam"
                },
                new Station
                {
                    Id = 10,
                    Longitude = 106.71548797723645,
                    Latitude = 10.796160596763055,
                    Name = "Ga Metro Khu du lịch Văn Thánh",
                    Address = "QPW8+C5Q, Phường 22, Bình Thạnh, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 11,
                    Longitude = 106.76576466834388,
                    Latitude = 10.836558412392224,
                    Name = "Ga Metro Bình Thái",
                    Address = "39761 Nguyễn Văn Bá, Phước Long B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 12,
                    Longitude = 106.78914067676806,
                    Latitude = 10.855748533595877,
                    Name = "AI InnovationHub",
                    Address = "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 13,
                    Longitude = 106.79643313765459,
                    Latitude = 10.853144521692798,
                    Name = "Tòa nhà HD Bank",
                    Address = "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 14,
                    Longitude = 106.79857191639908,
                    Latitude = 10.851138424399943,
                    Name = "FPT Software - Ftown 1,2",
                    Address = "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh "
                },
                new Station
                {
                    Id = 15,
                    Longitude = 106.80737654998441,
                    Latitude = 10.842755223277589,
                    Name = "Tòa nhà VPI phía Nam",
                    Address = "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 16,
                    Longitude = 106.80898373894351,
                    Latitude = 10.841160382489567,
                    Name = "Viện công nghệ cao Hutech",
                    Address = "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 17,
                    Longitude = 106.814245107947,
                    Latitude = 10.836238463608794,
                    Name = "Cổng Jabil Việt Nam",
                    Address = "RRP7+CJ7 đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 18,
                    Longitude = 106.82046132230808,
                    Latitude = 10.832233088594503,
                    Name = "Saigon Silicon",
                    Address = "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 19,
                    Longitude = 106.81401100053891,
                    Latitude = 10.836776238894464,
                    Name = "ISMARTCITY (ISC)",
                    Address = "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 20,
                    Longitude = 106.8099978721756,
                    Latitude = 10.84057839865839,
                    Name = "Trường đại học FPT",
                    Address = "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 21,
                    Longitude = 106.80454376198392,
                    Latitude = 10.84578835745819,
                    Name = "Công Ty CP Công Nghệ Sinh Học Dược Nanogen",
                    Address = "Đường D1, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 22,
                    Longitude = 106.79658230436019,
                    Latitude = 10.853375488919204,
                    Name = "Intel VietNam",
                    Address = "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 88,
                    Longitude = 106.79375338625633,
                    Latitude = 10.854367872934622,
                    Name = "Nidec VietNam",
                    Address = "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 23,
                    Longitude = 106.79189382870402,
                    Latitude = 10.854860900718421,
                    Name = "CMC Data Center",
                    Address = "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 24,
                    Longitude = 106.78924956530844,
                    Latitude = 10.856082809107784,
                    Name = "Inverter ups Sài Gòn",
                    Address = "Đường D1, Tân Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 25,
                    Longitude = 106.81035219090674,
                    Latitude = 10.838027429470513,
                    Name = "Trường đại học Nguyễn Tất Thành",
                    Address = "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 26,
                    Longitude = 106.80776601621393,
                    Latitude = 10.834922120966135,
                    Name = "FPT Software - Ftown 3",
                    Address = "Đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 27,
                    Longitude = 106.80727419233645,
                    Latitude = 10.834215900566933,
                    Name = "Công ty Cổ phần Hàng không VietJet",
                    Address = "RRM4+VMQ đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 28,
                    Longitude = 106.80598499131753,
                    Latitude = 10.832245246386895,
                    Name = "Sài Gòn Trapoco",
                    Address = "RRJ4+X9F đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 29,
                    Longitude = 106.80503995362199,
                    Latitude = 10.830911650064834,
                    Name = "Công ty kỹ thuật công nghệ cao sài gòn",
                    Address = "RRJ4+G2J đường Võ Chí Công, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 30,
                    Longitude = 106.79860212469366,
                    Latitude = 10.82585887552752,
                    Name = "Nhà máy Samsung Khu CNC",
                    Address = "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 31,
                    Longitude = 106.8001755286645,
                    Latitude = 10.826685687856866,
                    Name = "Công ty công nghệ cao Điện Quang",
                    Address = "Đường D2, Tăng Nhơn Phú B, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 32,
                    Longitude = 106.80446003004153,
                    Latitude = 10.829932294153192,
                    Name = "Công ty Thảo Dược Việt Nam",
                    Address = "G23 Lã Xuân Oai, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 33,
                    Longitude = 106.80512235256614,
                    Latitude = 10.830577375598693,
                    Name = "Công ty Daihan Vina",
                    Address = "1-2 đường D2, Long Thạnh Mỹ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 34,
                    Longitude = 106.78773791444128,
                    Latitude = 10.867306661370069,
                    Name = "Trường Đại học Nông Lâm",
                    Address = "VQ8Q+W5W QL 1A, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 35,
                    Longitude = 106.77793783791677,
                    Latitude = 10.869235667646493,
                    Name = "Trường đại học Kinh Tế Luật",
                    Address = "QL 1A, Linh Xuân, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 36,
                    Longitude = 106.80277007274188,
                    Latitude = 10.871997549994893,
                    Address = "VRC2+QR9, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 37,
                    Longitude = 106.80144678877895,
                    Latitude = 10.875092307642346,
                    Name = "Nhà Văn Hóa Sinh Viên ĐHQG",
                    Address = "VRF2+XFW đường Quảng Trường Sáng Tạo, Đông Hoà, Dĩ An, Bình Dương"
                },
                new Station
                {
                    Id = 38,
                    Longitude = 106.80198596270417,
                    Latitude = 10.870481440652956,
                    Name = "Cổng A - Trường đại học Công Nghệ Thông Tin",
                    Address = "Đường Hàn Thuyên, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 39,
                    Longitude = 106.79628492520538,
                    Latitude = 10.870503469555034,
                    Name = "Trường đại học Thể dục Thể thao",
                    Address = "VQCW+FG2, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 40,
                    Longitude = 106.79903376051722,
                    Latitude = 10.875477130935243,
                    Name = "Trường đại học Khoa học Tự nhiên (cơ sở Linh Trung)",
                    Address = "Đường T1, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 41,
                    Longitude = 106.80177999819321,
                    Latitude = 10.876446815885343,
                    Name = "Trường đại học Quốc Tế",
                    Address = "Đường Quảng Trường Sáng Tạo, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 42,
                    Longitude = 106.80614795287057,
                    Latitude = 10.878197830285536,
                    Name = "Cổng kí túc xá khu A (đại học quốc gia TP Hồ Chí Minh)",
                    Address = "Đường Tạ Quang Bửu, Linh Trung, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 43,
                    Longitude = 106.80697880277312,
                    Latitude = 10.879768516539494,
                    Name = "Trường đại học Bách Khoa (cơ sở 2)",
                    Address = "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương"
                },
                new Station
                {
                    Id = 44,
                    Longitude = 106.80552329008295,
                    Latitude = 10.877545337230165,
                    Name = "Trung tâm ngoại ngữ đại học Bách Khoa (BK English)",
                    Address = "Đường Tạ Quang Bửu, Đông Hòa, Dĩ An, Bình Dương"
                },
                new Station
                {
                    Id = 45,
                    Longitude = 106.77164269167564,
                    Latitude = 10.849721027334326,
                    Name = "Trường đại học Sư phạm Kĩ thuật Thành phố Hồ Chí Minh",
                    Address = "Số 1 đường Võ Văn Ngân, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 46,
                    Longitude = 106.7599477126918,
                    Latitude = 10.851623294286195,
                    Name = "Trường Cao đẳng Công nghệ Thủ Đức",
                    Address = "VQ25+JWQ đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 50,
                    Longitude = 106.76018734231964,
                    Latitude = 10.852653003274197,
                    Name = "Trung tâm thể dục thể thao Thủ Đức",
                    Address = "26 đường Chương Dương, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 51,
                    Longitude = 106.76032173572378,
                    Latitude = 10.854723648720167,
                    Name = "Trường Cao đẳng Nghề Thành phố Hồ Chí Minh",
                    Address = "19A đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 52,
                    Longitude = 106.76151598927879,
                    Latitude = 10.855800383594074,
                    Name = "Trường đại học Ngân hàng",
                    Address = "VQ46+9J3 đường số 17, Linh Chiểu, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 53,
                    Longitude = 106.76359240459003,
                    Latitude = 10.83090741994997,
                    Name = "Trường đại học Điện Lực",
                    Address = "356 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 54,
                    Longitude = 106.76462343340792,
                    Latitude = 10.83178168454807,
                    Name = "Metro Star - Quận 9 | Tập đoàn CT Group+",
                    Address = "360 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 55,
                    Longitude = 106.76388396745739,
                    Latitude = 10.830438851236304,
                    Name = "Chi nhánh công ty CyberTech Việt Nam",
                    Address = "354-356B Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 56,
                    Longitude = 106.76426274528296,
                    Latitude = 10.829834904338366,
                    Name = "Zenpix Việt Nam",
                    Address = "RQH7+XP4 Xa lộ, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 57,
                    Longitude = 106.76509820241216,
                    Latitude = 10.840946385700587,
                    Name = "Nhà máy sữa Thống Nhất (Vinamilk)",
                    Address = "12 Đặng Văn Bi, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 58,
                    Longitude = 106.76088713432273,
                    Latitude = 10.840432688988782,
                    Name = "Công ty xuất nhập khẩu Tây Tiến",
                    Address = "10/42 đường Số 4, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 59,
                    Longitude = 106.76276736279874,
                    Latitude = 10.844257732572313,
                    Name = "Trung tâm tiêm chủng vắc xin VNVC",
                    Address = "102 Đặng Văn Bi, Bình Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 60,
                    Longitude = 106.75924170740572,
                    Latitude = 10.825780208240717,
                    Name = "Công ty cổ phần Thép Thủ Đức",
                    Address = "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 61,
                    Longitude = 106.7609296886313,
                    Latitude = 10.82825779372371,
                    Name = "Công Ty Cổ Phần Cơ Điện Thủ Đức",
                    Address = "Km9 Xa lộ Hà Nội, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 62,
                    Longitude = 106.75761821078893,
                    Latitude = 10.827423240919156,
                    Name = "Công ty TNHH Nhiệt điện Thủ Đức",
                    Address = "RQH5+324 đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 63,
                    Longitude = 106.75322566624341,
                    Latitude = 10.827933659643358,
                    Name = "Cảng Trường Thọ",
                    Address = "Đường Số 1, Trường Thọ, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 64,
                    Longitude = 106.75928223003976,
                    Latitude = 10.82037580579453,
                    Name = "Công ty TNHH BeuHomes",
                    Address = "96 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 65,
                    Longitude = 106.76019934624064,
                    Latitude = 10.821744734671684,
                    Name = "Công ty TNHH Creative Engineering",
                    Address = "9 Nam Hòa, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 66,
                    Longitude = 106.75952721927021,
                    Latitude = 10.82220109625001,
                    Name = "Công Ty Công Nghệ Trí Tuệ Nhân Tạo AITT",
                    Address = "22/15 đường số 440, Phước Long A, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 67,
                    Longitude = 106.75206770837505,
                    Latitude = 10.805200229819087,
                    Name = "Golfzon Park Thảo Điền",
                    Address = "628C Xa lộ Hà Nội, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 68,
                    Longitude = 106.7488580702081,
                    Latitude = 10.803332925851043,
                    Name = "Saigon Town and Country Club",
                    Address = "Đường Giang Văn Minh, An Phú, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 69,
                    Longitude = 106.74393815975716,
                    Latitude = 10.804563036954756,
                    Name = "The Nassim Thảo Điền",
                    Address = "30 đường số 11, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 70,
                    Longitude = 106.74530677686282,
                    Latitude = 10.807262850388623,
                    Name = "Blue Mangoo Software",
                    Address = "RP4W+V3J đường Mai Chí Thọ, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 71,
                    Longitude = 106.73134189331353,
                    Latitude = 10.805401459108982,
                    Name = "Trường Đại học Văn hóa TP.HCM - Cơ sở 1",
                    Address = "51 đường Quốc Hương, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 72,
                    Longitude = 106.72928364712546,
                    Latitude = 10.806048021383644,
                    Name = "Trường song ngữ quốc tế Horizon",
                    Address = "6-6A 8 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 73,
                    Longitude = 106.72846844993934,
                    Latitude = 10.80927086483137,
                    Name = "Công Ty TNHH Dịch Vụ Địa Ốc Thảo Điền",
                    Address = "45 đường số 44, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 74,
                    Longitude = 106.72589627507526,
                    Latitude = 10.806246963358644,
                    Name = "Công Ty TNHH Một Thành Viên Ánh Sáng Hoàng ĐP",
                    Address = "40 đường Nguyễn Văn Hưởng, Thảo Điền, Thành phố Thủ Đức, Thành Phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 75,
                    Longitude = 106.72806621661472,
                    Latitude = 10.803458791026568,
                    Name = "Trường đại học Quốc Tế Thành phố Hồ Chí Minh",
                    Address = "1 đường Xuân Thủy, Thảo Điền, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 76,
                    Longitude = 106.73143206816108,
                    Latitude = 10.797897644669561,
                    Name = "SCB Trần Não - Ngân hàng TMCP Sài Gòn",
                    Address = "91B đường Trần Não, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 77,
                    Longitude = 106.7293406127999,
                    Latitude = 10.793905585531592,
                    Name = "Công Ty TNHH Xuất Nhập Khẩu Máy Móc Và Phụ Tùng Ô Tô Hưng Thịnh",
                    Address = "6 đường số 26, Bình Khánh, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 78,
                    Longitude = 106.72895399848618,
                    Latitude = 10.789891277804319,
                    Name = "Tòa nhà Microspace Building",
                    Address = "220 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 79,
                    Longitude = 106.72783903612815,
                    Latitude = 10.786711346588366,
                    Name = "Công ty TNHH vận tải - thi công cơ giới Xuân Thao",
                    Address = "18/2 đường số 35, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 80,
                    Longitude = 106.72849002239546,
                    Latitude = 10.780549913195312,
                    Name = "Công Ty TNHH Ch Resource Vietnam",
                    Address = "9 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 81,
                    Longitude = 106.72969521262236,
                    Latitude = 10.786744237747117,
                    Name = "Công Ty TNHH Thương Mại Và Dịch Vụ Nhật Vượng",
                    Address = "10 đường số 39, Bình Trưng Tây, Thành Phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 82,
                    Longitude = 106.73067177064897,
                    Latitude = 10.792554668741762,
                    Name = "Ngân hàng TMCP Kỹ thương Việt Nam (Techcombank)- Chi nhánh Gia Định - PGD Trần Não",
                    Address = "125 đường Trần Não, Bình An, Thành phố Thủ Đức, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 83,
                    Longitude = 106.72126763097279,
                    Latitude = 10.798737294717368,
                    Name = "Tòa Nhà Melody Tower, Cty Toi",
                    Address = "25 Ung Văn Khiêm, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 84,
                    Longitude = 106.71843607604076,
                    Latitude = 10.799795706410299,
                    Name = "Pearl Plaza Văn Thánh",
                    Address = "561A đường Điện Biên Phủ, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 85,
                    Longitude = 106.71812789316297,
                    Latitude = 10.802303255825205,
                    Name = "Căn hộ Wilton Tower",
                    Address = "15 Nguyễn Văn Thương, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 86,
                    Longitude = 106.7167285754774,
                    Latitude = 10.804470786914793,
                    Name = "Trường đại học Giao Thông Vận Tải",
                    Address = "02 Võ Oanh, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh"
                },
                new Station
                {
                    Id = 87,
                    Longitude = 106.71296786250547,
                    Latitude = 10.80656432638495,
                    Name = "Trường Đại học Ngoại thương - Cơ sở 2",
                    Address = "15 Đường D5, Phường 25, Bình Thạnh, Thành phố Hồ Chí Minh"
                },

            };
        }
        public static List<Domain.Entities.Route> DumpRoutes()
        {
            var routes = new List<Domain.Entities.Route>
            {
                // Ga Metro khu CNC - Saigon Silicon
                new Domain.Entities.Route
                {
                    Id = 1,
                    Steps = new List<Step>
                    {
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.78873468227272,
                                Latitude = 10.859159644127356
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.78762367699157,
                                Latitude = 10.858481253879473,
                            },
                            Distance = 210,
                            StationId = 3
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.78762367699157,
                                Latitude = 10.858481253879473,
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.78773950681367,
                                Latitude = 10.858246877998143
                            },
                            Distance = 25
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.78773950681367,
                                Latitude = 10.858246877998143
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.7877549233094,
                                Latitude = 10.858075137865129,
                            },
                            Distance = 15
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.7877549233094,
                                Latitude = 10.858075137865129,
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.78914063787107,
                                Latitude = 10.855776726730952
                            },
                            Distance = 260
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.78914063787107,
                                Latitude = 10.855776726730952
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.78955623309844,
                                Latitude = 10.855332998790804
                            },
                            Distance = 15,
                            StationId = 12
                        },
                        new Step
                        {
                            StartPoint =  new Location
                            {
                                Longitude = 106.78955623309844,
                                Latitude = 10.855332998790804
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.7898694619764,
                                Latitude = 10.855185979796433
                            },
                            Distance = 30,
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.7898694619764,
                                Latitude = 10.855185979796433
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.7955987705438,
                                Latitude = 10.853621177903287
                            },
                            Distance = 700,
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.7955987705438,
                                Latitude = 10.853621177903287
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.79643766186621,
                                Latitude = 10.853179473980733
                            },
                            Distance = 100
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.79643766186621,
                                Latitude = 10.853179473980733
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.79839846309746,
                                Latitude = 10.851291289346744
                            },
                            Distance = 300,
                            StationId = 13
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.79839846309746,
                                Latitude = 10.851291289346744
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.80739732231577,
                                Latitude = 10.842745298705701
                            },
                            Distance = 1300,
                            StationId = 14
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.80739732231577,
                                Latitude = 10.842745298705701
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.80902127301017,
                                Latitude = 10.841195991131912
                            },
                            Distance = 300,
                            StationId = 15
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.80902127301017,
                                Latitude = 10.841195991131912
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81091359724583,
                                Latitude = 10.839372615185303
                            },
                            Distance = 320,
                            StationId = 16
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81091359724583,
                                Latitude = 10.839372615185303
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81110136111522,
                                Latitude = 10.839024277330136
                            },
                            Distance = 50
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81110136111522,
                                Latitude = 10.839024277330136
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.811220847491,
                                Latitude = 10.838685252933196
                            },
                            Distance = 50
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.811220847491,
                                Latitude = 10.838685252933196
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81143469187305,
                                Latitude = 10.838572536557397
                            },
                            Distance = 30
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81143469187305,
                                Latitude = 10.838572536557397
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81161898381838,
                                Latitude = 10.838598957053494
                            },
                            Distance = 20
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81161898381838,
                                Latitude = 10.838598957053494
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81195559636497,
                                Latitude = 10.838362570201646
                            },
                            Distance = 50
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81195559636497,
                                Latitude = 10.838362570201646
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81204647060426,
                                Latitude = 10.838328868247837
                            },
                            Distance = 15
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81204647060426,
                                Latitude = 10.838328868247837
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81424130928508,
                                Latitude = 10.836254435066133
                            },
                            Distance = 300
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81424130928508,
                                Latitude = 10.836254435066133
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81815708677787,
                                Latitude = 10.833003663608592
                            },
                            Distance = 550,
                            StationId = 17
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81815708677787,
                                Latitude = 10.833003663608592
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81870834970695,
                                Latitude = 10.832765563011641
                            },
                            Distance = 100
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81870834970695,
                                Latitude = 10.832765563011641
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.8194137706895,
                                Latitude = 10.832491584781957
                            },
                            Distance = 50
                        },
                        new Step
                        {
                            StartPoint =  new Location
                            {
                                Longitude = 106.8194137706895,
                                Latitude = 10.832491584781957
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.82047324310263,
                                Latitude = 10.83223604632498
                            },
                            Distance = 150
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.82047324310263,
                                Latitude = 10.83223604632498
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.82077342729521,
                                Latitude = 10.832168273195903
                            },
                            Distance = 35,
                            StationId = 18
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.82077342729521,
                                Latitude = 10.832168273195903
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.8212724688972,
                                Latitude = 10.832103779478716
                            },
                            Distance = 55
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.8212724688972,
                                Latitude = 10.832103779478716
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.8222152193456,
                                Latitude = 10.832047584360758
                            },
                            Distance = 100
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.8222152193456,
                                Latitude = 10.832047584360758
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.82334152325834,
                                Latitude = 10.83212061460973
                            },
                            Distance = 210
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.82334152325834,
                                Latitude = 10.83212061460973
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.82325097706524,
                                Latitude = 10.832317810490105
                            },
                            Distance = 50
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.82325097706524,
                                Latitude = 10.832317810490105
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.82282035041021,
                                Latitude = 10.832249692217205
                            },
                            Distance = 50
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.82282035041021,
                                Latitude = 10.832249692217205
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.82163169091187,
                                Latitude = 10.832237586489393
                            },
                            Distance = 100
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.82163169091187,
                                Latitude = 10.832237586489393
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.8199853436173,
                                Latitude = 10.832508894206725
                            },
                            Distance = 200
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.8199853436173,
                                Latitude = 10.832508894206725
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81850764128805,
                                Latitude = 10.833037848488125
                            },
                            Distance = 180
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81850764128805,
                                Latitude = 10.833037848488125
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81844180576122,
                                Latitude = 10.83304609452443
                            },
                            Distance = 20
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81844180576122,
                                Latitude = 10.83304609452443
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81737330662962,
                                Latitude = 10.833608557029692
                            },
                            Distance = 100
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81737330662962,
                                Latitude = 10.833608557029692
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81550788354345,
                                Latitude = 10.835348946066285
                            },
                            Distance = 300
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81550788354345,
                                Latitude = 10.835348946066285
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81399511982826,
                                Latitude = 10.836760978276654
                            },
                            Distance = 200
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81399511982826,
                                Latitude = 10.836760978276654
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81206872703387,
                                Latitude = 10.838527995191129
                            },
                            Distance = 290,
                            StationId = 19,
                        },
                        new Step
                        {
                            StartPoint =  new Location
                            {
                                Longitude = 106.81206872703387,
                                Latitude = 10.838527995191129
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81187431040269,
                                Latitude = 10.838974896526736
                            },
                            Distance = 60
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81187431040269,
                                Latitude = 10.838974896526736
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81169023450728,
                                Latitude = 10.839295853438287
                            },
                            Distance = 50
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81169023450728,
                                Latitude = 10.839295853438287
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81152063711082,
                                Latitude = 10.839348667814898
                            },
                            Distance = 15
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81152063711082,
                                Latitude = 10.839348667814898
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81137585820771,
                                Latitude = 10.839332416948443
                            },
                            Distance = 10
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81137585820771,
                                Latitude = 10.839332416948443
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.81042031931308,
                                Latitude = 10.840104334290078
                            },
                            Distance = 150
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.81042031931308,
                                Latitude = 10.840104334290078
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.80953716971482,
                                Latitude = 10.841008288243124
                            },
                            Distance = 150
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.80953716971482,
                                Latitude = 10.841008288243124
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.80432554120699,
                                Latitude = 10.845917934141822
                            },
                            Distance = 800,
                            StationId = 20
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.80432554120699,
                                Latitude = 10.845917934141822
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.7965662300359,
                                Latitude = 10.853308819026587
                            },
                            Distance = 1200,
                            StationId = 21
                        },
                        new Step
                        {
                            StartPoint =  new Location
                            {
                                Longitude = 106.7965662300359,
                                Latitude = 10.853308819026587
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.79527269646111,
                                Latitude = 10.853939538153051
                            },
                            Distance = 160,
                            StationId = 22
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.79527269646111,
                                Latitude = 10.853939538153051
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.79374668425537,
                                Latitude = 10.854347767089786
                            },
                            Distance = 200
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.79374668425537,
                                Latitude = 10.854347767089786
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.79197509284505,
                                Latitude = 10.854860525377829
                            },
                            Distance = 200,
                            StationId = 88
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.79197509284505,
                                Latitude = 10.854860525377829
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.79000790133418,
                                Latitude = 10.855365324773711
                            },
                            Distance = 230,
                            StationId = 23
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.79000790133418,
                                Latitude = 10.855365324773711
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.78929659747766,
                                Latitude = 10.855844617144058
                            },
                            Distance = 70
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.78929659747766,
                                Latitude = 10.855844617144058
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.78917857815927,
                                Latitude = 10.856032574730769
                            },
                            Distance = 50
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.78917857815927,
                                Latitude = 10.856032574730769
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.78784952422014,
                                Latitude = 10.858220130533422
                            },
                            Distance = 290,
                            StationId = 24
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.78784952422014,
                                Latitude = 10.858220130533422
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.78774414420087,
                                Latitude = 10.858259985859267
                            },
                            Distance = 10
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.78774414420087,
                                Latitude = 10.858259985859267
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.78763061017965,
                                Latitude = 10.858470123350822
                            },
                            Distance = 50
                        },
                        new Step
                        {
                            StartPoint = new Location
                            {
                                Longitude = 106.78763061017965,
                                Latitude = 10.858470123350822
                            },
                            EndPoint = new Location
                            {
                                Longitude = 106.78873468227272,
                                Latitude = 10.859159644127356
                            },
                            Distance = 210
                        }
                    }
                }
            };

            CaculateDuration(routes);

            return routes;
        }
        public static List<RouteStation> DumpRouteStations(List<Domain.Entities.Route> routes)
        {
            List<RouteStation> routeStations = new();
            for (int index = 0; index < routes.Count; index++)
            {
                var route = routes[index];

                var stationsId = route.Steps.Select(step => step.StationId).Where(stationId => stationId != null).ToList();

                double DistanceFromFirstStationInRoute = 0;
                int stationIndex = 0;

                route.Steps.ForEach(step =>
                {
                    if(step.StationId.HasValue)
                    {
                        routeStations.Add(new RouteStation
                        {
                            Id = routeStations.Count() + 1,
                            Index = stationIndex++,
                            DistanceFromFirstStationInRoute = DistanceFromFirstStationInRoute,
                            StationId = step.StationId.Value,
                            RouteId = route.Id
                        });
                    }
                    else
                    {
                        //DistanceFromFirstStationInRoute += step.Distance;
                        //stationIndex++;
                    }
                    DistanceFromFirstStationInRoute += step.Distance;
                });

                routeStations.Last().Index = -1;
            }

            return routeStations;
        }

    }
}

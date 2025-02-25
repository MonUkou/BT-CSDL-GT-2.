using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Baitap2._2
{
    class Program
    {
        /*
         * 1.Thiết kế và thực thi một lớp cho phép giáo viên có thể theo dõi điểm số của một môn học (sử dụng Array)
         * Bổ sung các phương thức cho phép tính điểm trung bình, xác định điểm trung bình, điểm cao nhất và thấp nhất
         * 2.Chỉnh sửa bài tập 1 để chương trình có thể theo dõi điểm số của nhiều môn học
         * 3.Viết lại bài tập 1 bằng sử dụng List
         * 4.Viết lại bài tập 1 bằng sử dụng ArrayList
         * 5.So sánh thời gian thực thi của bài 1, 3, 4
         */
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.UTF8;

            Timing timecounter = new Timing(); //Khởi tạo một đối tượng timecounter của lớp Timing để đo thời gian thực thi

            int ntimes = 100000000; //Số lần lặp lại để đo hiệu suất

            Console.Write("Mời bạn nhập số môn học: ");
            int n = Convert.ToInt32(Console.ReadLine());
            

            Console.WriteLine("-----------------------");
           
            Array array1 = TaoMang.createArray(typeof(double), 3);

            Console.WriteLine("Mời bạn nhập điểm Toán theo thứ tự Điểm Thường Xuyên-Điểm Giữa Kỳ-Điểm Cuối Kỳ: ");
            for (int i = 0; i < array1.Length; i++)
                array1.SetValue(Convert.ToDouble(Console.ReadLine()), i);
            Console.WriteLine($"Điểm trung bình của môn Toán: {TinhDiem.averageScore(array1)}");
            Console.WriteLine($"Điểm cao nhất của môn Toán: {TinhDiem.maxScore(array1)}");
            Console.WriteLine($"Điểm thấp nhất của môn Toán: {TinhDiem.minScore(array1)}");
            Console.WriteLine("-----------------------");
            
            //Mở rộng 
            //Sử dụng Array
            Array arrays = TaoMang.createArray(typeof(double), n);
            for (int i = 0; i < n; i++)
            {
                Array arrMon = TaoMang.createArray(typeof(double), 3);
                arrays.SetValue(arrMon.GetValue(0), i); 
                Console.Write($"Mời bạn nhập tên môn học thứ {i + 1}: ");
                string subject = Console.ReadLine();
                Console.WriteLine("-----");
                Console.WriteLine($"Mời bạn nhập điểm môn {subject} theo thứ tự Điểm Thường Xuyên-Điểm Giữa Kỳ-Điểm Cuối Kỳ: ");
                for (int j = 0; j < 3; j++)
                    arrMon.SetValue(Convert.ToDouble(Console.ReadLine()), j);
                Console.WriteLine("KẾT QUẢ");
                Console.WriteLine($"Điểm trung bình của môn {subject}: {TinhDiem.averageScore(arrMon)}");
                Console.WriteLine($"Điểm cao nhất của môn {subject}: {TinhDiem.maxScore(arrMon)}");
                Console.WriteLine($"Điểm thấp nhất của môn {subject}: {TinhDiem.minScore(arrMon)}");
                Console.WriteLine($"Môn: {subject} | Điểm TB: {TinhDiem.averageScore(arrMon):F2} | Cao nhất: {TinhDiem.maxScore(arrMon):F2} | Thấp nhất: {TinhDiem.minScore(arrMon):F2}");
                Console.WriteLine("-----");
            }
            timecounter.startTime(); //Bắt đầu tính thời gian cho đối tượng
            for (int i = 0; i < ntimes; i++) { } //Vòng lặp chỉ đo thời gian thực thi
            timecounter.StopTime(); // Dừng tính thời gian cho đối tượng khi đặt đến số lần lặp tối đa (10000000)
            double a = timecounter.Result().Milliseconds / ntimes;
            Console.WriteLine($"Duration: {(double)a}ms"); //In ra thời gian trung bình lặp 
            Console.WriteLine("-----------------------");
            
            //Sử dụng List
            List<string> tenMon = new List<string>();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Mời bạn nhập tên môn học thứ {i + 1}: ");
                tenMon.Add(Console.ReadLine());
            }
            List<List<double>> dsDiem = new List<List<double>>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("-----");
                Console.WriteLine($"Mời bạn nhập điểm môn {tenMon[i]} theo thứ tự Điểm Thường Xuyên-Điểm Giữa Kỳ-Điểm Cuối Kỳ: ");
                List<double> diemMon = new List<double>();
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Nhập điểm thứ {j + 1} của môn {tenMon[i]}: ");
                    diemMon.Add(double.Parse(Console.ReadLine()));
                }
                dsDiem.Add(diemMon);
            }
            Console.WriteLine("KẾT QUẢ");
            for (int i = 0; i < n; i++)
            {
                List<double> diemSo = dsDiem[i];                
                Console.WriteLine($"Môn: {tenMon} | Điểm TB: {(double)diemSo.Average():F2} | Cao nhất: {(double)diemSo.Max():F2} | Thấp nhất: {(double)diemSo.Min():F2}");
            }
            timecounter.startTime(); //Bắt đầu tính thời gian cho đối tượng
            for (int i = 0; i < ntimes; i++) { } //Vòng lặp chỉ đo thời gian thực thi
            timecounter.StopTime(); // Dừng tính thời gian cho đối tượng khi đặt đến số lần lặp tối đa (10000000)
            double b = timecounter.Result().Milliseconds / ntimes;
            Console.WriteLine($"Duration: {(double)b}ms"); //In ra thời gian trung bình lặp 
            Console.WriteLine("-----------------------");

            //Sử dụng ArrayList
            ArrayList monHoc = TaoMang.createArrayList();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Mời bạn nhập tên môn học thứ {i + 1}: ");
                string tenmon = Console.ReadLine();
                ArrayList diemMon = new ArrayList();

                Console.WriteLine("-----");
                Console.WriteLine($"Mời bạn nhập điểm môn {tenmon} theo thứ tự Điểm Thường Xuyên - Giữa Kỳ - Cuối Kỳ: ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Mời bạn nhập điểm thứ {j + 1} của môn {tenmon}: ");
                    diemMon.Add(Convert.ToDouble(Console.ReadLine()));
                }

                ArrayList MonDiem = new ArrayList { tenmon, diemMon };
                monHoc.Add(MonDiem);
            }

            Console.WriteLine("Kết quả:");
            for (int i = 0; i < monHoc.Count; i++)
            {
                ArrayList monhoc = (ArrayList)monHoc[i]; // Lấy thông tin môn học
                string tenmonhoc = (string)monhoc[0]; // Tên môn học
                ArrayList diemMon = (ArrayList)monhoc[1]; // Danh sách điểm

                double diemTB = 0, diemMin = (double)diemMon[0], diemMax = (double)diemMon[0];

                for (int j = 0; j < diemMon.Count; j++)
                {
                    double diem = (double)diemMon[j];
                    diemTB += diem;
                    if (diem < diemMin) diemMin = diem;
                    if (diem > diemMax) diemMax = diem;
                }
                diemTB /= diemMon.Count;
                Console.WriteLine($"Môn: {tenmonhoc} | Điểm TB: {diemTB:F2} | Cao nhất: {diemMax} | Thấp nhất: {diemMin}");
            }
            timecounter.startTime(); //Bắt đầu tính thời gian cho đối tượng
            for (int i = 0; i < ntimes; i++) { } //Vòng lặp chỉ đo thời gian thực thi
            timecounter.StopTime(); // Dừng tính thời gian cho đối tượng khi đặt đến số lần lặp tối đa (10000000)
            double c = timecounter.Result().Milliseconds / ntimes;
            Console.WriteLine($"Duration: {(double)c}ms"); //In ra thời gian trung bình lặp 
            Console.WriteLine("-----------------------");
            
            double max = a, min = a;

            if (b > max) max = b;
            if (c > max) max = c;

            if (b < min) min = b;
            if (c < min) min = c;

            // Xuất kết quả
            Console.WriteLine($"Nhanh nhất là: {max}");
            Console.WriteLine($"chậm nhất là: {min}");

            Console.ReadKey();
        }
    }
}

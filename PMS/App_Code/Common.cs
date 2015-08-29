using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

using DevExpress.XtraGrid.Localization;
using DevExpress.XtraEditors.Controls;
using System.IO;

namespace PMS.App_Code
{
    public class Common
    {

        public static string UploadFile(byte[] f, string fileName)
        {
            // the byte array argument contains the content of the file
            // the string argument contains the name and extension
            // of the file passed in the byte array
            try
            {
                fileName = DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + fileName;
                // instance a memory stream and pass the
                // byte array to its constructor
                MemoryStream ms = new MemoryStream(f);

                // instance a filestream pointing to the 
                // storage folder, use the original file name
                // to name the resulting file
                //FileStream fs = new FileStream
                //    (System.Web.Hosting.HostingEnvironment.MapPath("~/TransientStorage/") +
                //    fileName, FileMode.Create);
                FileStream fs = new FileStream
                   ("C:\\inetpub\\wwwroot\\DataExcel\\" +
                   fileName, FileMode.Create);

                // write the memory stream containing the original
                // file as a byte array to the filestream
                ms.WriteTo(fs);

                // clean up
                ms.Close();
                fs.Close();
                fs.Dispose();

                // return OK if we made it this far
                return "OK";
            }
            catch (Exception ex)
            {
                // return the error message if the operation fails
                return ex.Message.ToString();
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name=”T”>Custome Class </typeparam>
        /// <param name=”lst”>List Of The Custome Class</param>
        /// <returns> Return the class datatbl </returns>
        public static DataTable ConvertTo<T>(IList<T> lst)
        {
            //create DataTable Structure
            DataTable tbl = CreateTable<T>();
            Type entType = typeof(T);

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
            //get the list item and add into the list
            foreach (T item in lst)
            {
                DataRow row = tbl.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                tbl.Rows.Add(row);
            }

            return tbl;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name=”T”>Custome Class</typeparam>
        /// <returns></returns>
        public static DataTable CreateTable<T>()
        {
            //T –> ClassName
            Type entType = typeof(T);
            //set the datatable name as class name
            DataTable tbl = new DataTable(entType.Name);
            //get the property list
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
            foreach (PropertyDescriptor prop in properties)
            {
                //add property as column
                if (prop.PropertyType.Name.Contains("Nullable"))
                    tbl.Columns.Add(prop.Name, typeof(string));
                else
                    tbl.Columns.Add(prop.Name, prop.PropertyType);

            }
            return tbl;
        }
        /// <summary>
        /// ///////////////////////////////////////////////////
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static DataTable ConvertTo_New<T>(IList<T> lst)
        {
            //create DataTable Structure
            DataTable tbl = CreateTable_New<T>();
            Type entType = typeof(T);

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
            //get the list item and add into the list
            foreach (T item in lst)
            {
                DataRow row = tbl.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = ((prop.GetValue(item) == null) ? DBNull.Value : prop.GetValue(item));
                }
                tbl.Rows.Add(row);
            }

            return tbl;
        }
        public static DataTable CreateTable_New<T>()
        {
            //T –> ClassName
            Type entType = typeof(T);
            //set the datatable name as class name
            DataTable tbl = new DataTable(entType.Name);
            //get the property list
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
            foreach (PropertyDescriptor prop in properties)
            {
                //add property as column
                tbl.Columns.Add(prop.Name);
            }
            return tbl;
        }
        public static string ConvertString(string stringInput)
        {
            stringInput = stringInput.ToUpper();
            string convert = "ĂÂÀẰẦÁẮẤẢẲẨÃẴẪẠẶẬỄẼỂẺÉÊÈỀẾẸỆÔÒỒƠỜÓỐỚỎỔỞÕỖỠỌỘỢƯÚÙỨỪỦỬŨỮỤỰÌÍỈĨỊỲÝỶỸỴĐăâàằầáắấảẳẩãẵẫạặậễẽểẻéêèềếẹệôòồơờóốớỏổởõỗỡọộợưúùứừủửũữụựìíỉĩịỳýỷỹỵđ";
            string To = "AAAAAAAAAAAAAAAAAEEEEEEEEEEEOOOOOOOOOOOOOOOOOUUUUUUUUUUUIIIIIYYYYYDaaaaaaaaaaaaaaaaaeeeeeeeeeeeooooooooooooooooouuuuuuuuuuuiiiiiyyyyyd";
            for (int i = 0; i < To.Length; i++)
            {
                stringInput = stringInput.Replace(convert[i], To[i]);
                stringInput = stringInput.Replace(" ", "");
            }
            return stringInput;
        }
        public static List<Thang> GetDSThang()
        {
            List<Thang> listThang = new List<Thang>() { new Thang { So = 1, Ten = "Tháng 1" },
                new Thang { So = 2, Ten = "Tháng 2" }, 
                new Thang { So = 3, Ten = "Tháng 3" }, 
                new Thang { So = 4, Ten = "Tháng 4" }, 
                new Thang { So = 5, Ten = "Tháng 5" }, 
                new Thang { So = 6, Ten = "Tháng 6" }, 
                new Thang { So = 7, Ten = "Tháng 7" }, 
                new Thang { So = 8, Ten = "Tháng 8" }, 
                new Thang { So = 9, Ten = "Tháng 9" }, 
                new Thang { So = 10, Ten = "Tháng 10" }, 
                new Thang { So = 11, Ten = "Tháng 11" }, 
                new Thang { So = 12, Ten = "Tháng 12" } };
            return listThang;
        }
        public static List<ThaiDoKhachHang> GetDSThaiDoKH()
        {
            List<ThaiDoKhachHang> listThaiDoKH = new List<ThaiDoKhachHang>() { new ThaiDoKhachHang { Ma = 1, Ten = "Hài lòng" },
                new ThaiDoKhachHang { Ma = 2, Ten = "Bình thường" }, 
                new ThaiDoKhachHang { Ma = 3, Ten = "Không hài lòng" }};
            return listThaiDoKH;
        }
        public static List<LyDoGoi> GetDSLyDoGoi()
        {
            List<LyDoGoi> listLyDoGoi = new List<LyDoGoi>() { new LyDoGoi { Ma = 1, Ten = "Xác nhận thông tin gửi sinh nhật" },
                new LyDoGoi { Ma = 2, Ten = "Xác nhận, nhận thư sinh nhật" }, 
                new LyDoGoi { Ma = 6, Ten = "Xác nhận thông tin gửi thẻ" },
                new LyDoGoi { Ma = 3, Ten = "Xác nhận, nhận thẻ nâng cấp" }, 
                new LyDoGoi { Ma = 4, Ten = "Lý do khác" },
                new LyDoGoi { Ma = 5, Ten = "Ý kiến khách hàng" }};
            return listLyDoGoi;
        }
        public static List<Complaint> GetDSComplaint()
        {
            List<Complaint> listComplaint = new List<Complaint>() { new Complaint { Ma = 1, Ten = "* Headache",Select=false },
                new Complaint { Ma = 2, Ten = "* Neck pain",Select=false }, 
                new Complaint { Ma = 3, Ten = "* Arm/hand pain",Select=false },
                new Complaint { Ma = 4, Ten = "* Shoulder pain",Select=false }, 
                new Complaint { Ma = 5, Ten = "* Upper back pain",Select=false },
                new Complaint { Ma = 6, Ten = "* Mid-back pain",Select=false },
                new Complaint { Ma = 7, Ten = "* Low back pain",Select=false },
                new Complaint { Ma = 8, Ten = "* Knee pain",Select=false },
                new Complaint { Ma = 9, Ten = "* Leg/foot pain",Select=false }};
            return listComplaint;
        }
        public static List<MRIImage> GetDSMRIImage()
        {
            List<MRIImage> listMRIImage = new List<MRIImage>() { new MRIImage { Ma = 1, Ten = "* Cervival Degeneration",Select=false },
                new MRIImage { Ma = 2, Ten = "* Cervival disc herniation(s)",Select=false }, 
                new MRIImage { Ma = 3, Ten = "* Cervival segmental joint dysfuntion",Select=false },
                new MRIImage { Ma = 4, Ten = "* Cervival strain/sprain",Select=false }, 
                new MRIImage { Ma = 5, Ten = "* Shoulder strain/sprain",Select=false },
                new MRIImage { Ma = 6, Ten = "* Thoracic segmental joint dysfuntion",Select=false },
                new MRIImage { Ma = 7, Ten = "* Thoracic strain/sprain",Select=false },
                new MRIImage { Ma = 8, Ten = "* Lumbar Degeneration",Select=false },
                new MRIImage { Ma = 9, Ten = "* Lumbar disc herniation(s)",Select=false }, 
                new MRIImage { Ma = 10, Ten = "* Lumbar segmental joint dysfuntion",Select=false },
                new MRIImage { Ma = 11, Ten = "* Knee osteoarthritis",Select=false },
                new MRIImage { Ma = 12, Ten = "* Ankle strain/sprain",Select=false },
                new MRIImage { Ma = 13, Ten = "* Feet treatment",Select=false }};
            return listMRIImage;
        }
        public static List<DiscAndJoint> GetDSDiscAndJoint()
        {
            List<DiscAndJoint> listDiscAndJoint = new List<DiscAndJoint>() { new DiscAndJoint { Ma = 1, Ten = "C1 - C2",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false },
                new DiscAndJoint { Ma = 2, Ten = "C2 - C3",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false }, 
                new DiscAndJoint { Ma = 3, Ten = "C3 - C4",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 4, Ten = "C4 - C5",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false}, 
                new DiscAndJoint { Ma = 5, Ten = "C5 - C6",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 6, Ten = "C6 - C7",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 7, Ten = "C7 - T1",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                                
                //new DiscAndJoint { Ma = 80},
               
                new DiscAndJoint { Ma = 8, Ten = "T1 - T2",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 9, Ten = "T2 - T3",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false}, 
                new DiscAndJoint { Ma = 10,Ten = "T3 - T4",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 11,Ten = "T4 - T5",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 12,Ten = "T5 - T6",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 13,Ten = "T6 - T7",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 14, Ten = "T7 - T8",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false}, 
                new DiscAndJoint { Ma = 15,Ten = "T8 - T9",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 16,Ten = "T9 - T10",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 17,Ten = "T10 - T11",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 18,Ten = "T11 - T12",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 19,Ten = "T12 - L1",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},

                //new DiscAndJoint { Ma = 90},

                new DiscAndJoint { Ma = 20, Ten = "L1 - T2",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false}, 
                new DiscAndJoint { Ma = 21,Ten = "L2 - T3",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 22,Ten = "L3 - T4",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 23,Ten = "L4 - T5",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},
                new DiscAndJoint { Ma = 24,Ten = "L5 - S1",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false},

                //new DiscAndJoint { Ma = 99},

                new DiscAndJoint { Ma = 24,Ten = "S1 - S2",Degenerated=false,Bulging=false,Herniated=false,Spondylo=false,Stenois=false,FacetSynrome=false}};
            return listDiscAndJoint;
        }
        public static List<Vertebral> GetDSVertebral()
        {
            List<Vertebral> listDiscAndJoint = new List<Vertebral>() { new Vertebral { Ma = 1, Ten = "C1",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Blood supply to the head, pituitary gland, scalp, bones of the face, brain, inner and middle ear, sympathetic nervous system.",Possible="Headaches, nervousness, insomnia, head colds, high blood pressure, migraine headaches, nervous breakdowns, amnesia, chronic tiredness, dizziness."}, 
                new Vertebral { Ma = 2, Ten = "C2",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Eyes, optic nerves, auditory nerves, sinus, mastoid bones, tongue, forehead.",Possible="Sinus trouble, allergies, pain around the eyes, earache, fainting spells, certain causes of blindness, crossed eyes, deafness."}, 
                new Vertebral { Ma = 3, Ten = "C3",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Cheeks, outer ear, face bones, teeth, trifacial nerve.",Possible="Neuralgia, neuritis, acne or pimples, ecaema."}, 
                new Vertebral { Ma = 4, Ten = "C4",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Nose, lips, mouth, eurstachian tubes.",Possible="Hay fever, runny nose, hearing loss, adenoids."},  
                new Vertebral { Ma = 5, Ten = "C5",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Vocal cords, neck glands, pharynx.",Possible="Laryngitis, hoarseness, throat conditions such as sore throat or quinsy."}, 
                new Vertebral { Ma = 6, Ten = "C6",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Neck muscles, shoulders, tonsils.",Possible="Stiff neck, pain in upper arm, tonsilitis, chronic cough, croup."}, 
                new Vertebral { Ma = 7, Ten = "C7",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Thyroid gland, bursa in the shoulders, elbows.",Possible="Bursitis, colds, thyoid conditions."}, 
                                
                //new DiscAndJoint { Ma = 80},
               
                new Vertebral { Ma = 8, Ten = "T1",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Arms from the elbows down, including hands, wrists, and fingers, esophagus and trachea.",Possible="Asthma, cough, difficult breathing, shortness of breath, pain in lower arms and hands."}, 
                new Vertebral { Ma = 9, Ten = "T2",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Heart including its valves and covering, also coronary arteries.",Possible="Functional heart conditions and certain chest pains."},  
                new Vertebral { Ma = 10,Ten = "T3",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Lungs, bronchial tubes, chest, breast, nipples.",Possible="Bronchitis, pleurisy, pneumonia, congestion, influenza."}, 
                new Vertebral { Ma = 11,Ten = "T4",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Gallbladder, common duct.",Possible="Gallbladder conditions, jaundice, shingles"}, 
                new Vertebral { Ma = 12,Ten = "T5",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Liver, solar plexus, circulation.",Possible="Liver conditions, fevers, low blood pressure, anaemia, poor circulation, arthritis."}, 
                new Vertebral { Ma = 13,Ten = "T6",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Stomach.",Possible="Stomach troubles, including nervous stomach, indigestion, heartburn, dyspepsia."}, 
                new Vertebral { Ma = 14, Ten = "T7",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Pancreas, duodenum.",Possible="Ulcers, gastritis."},  
                new Vertebral { Ma = 15,Ten = "T8",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Spleen.",Possible="Lowered resistance."}, 
                new Vertebral { Ma = 16,Ten = "T9",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Adrenals or supra renals.",Possible="Allergies and hives."}, 
                new Vertebral { Ma = 17,Ten = "T10",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Kidneys.",Possible="Kidney troubles, hardened arteries, chronic tiredness, nephritis, pyelitis."}, 
                new Vertebral { Ma = 18,Ten = "T11",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Kidneys, ureters.",Possible="Skin conditions such as acne, pimples, eczema, or boils."}, 
                new Vertebral { Ma = 19,Ten = "T12",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Small intestines, lymph circulation.",Possible="Rheumatism, gas pains, certain types of sterility."}, 

                //new DiscAndJoint { Ma = 90},

                new Vertebral { Ma = 20, Ten = "L1",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Large intestines, inguinal rings.",Possible="Constipation, colitis, dysentery, diarrhea, some ruptures or hernias."},  
                new Vertebral { Ma = 21,Ten = "L2",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Appendix, abdomen, upper leg.",Possible="Cramps, difficult breathing, acidosis, varicose veins."}, 
                new Vertebral { Ma = 22,Ten = "L3",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Sex organs, uterus, bladder, knees.",Possible="Bladder troubles, menstrual troubles such as painful or irregular periods, miscarriages, bed wetting, impotency, change of life symptoms, many knee pains."}, 
                new Vertebral { Ma = 23,Ten = "L4",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Prostate gland, muscles of the lower back, sciatic nerve.",Possible="Sciatica, lumbago, difficult painful of too frequent urination, backaches."}, 
                new Vertebral { Ma = 24,Ten = "L5",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Lower legs, ankles, feet.",Possible="Poor circulation in the legs swollen ankles, weak ankles and arches, cold feet weakness of the legs, leg cramps."}, 

                //new DiscAndJoint { Ma = 99},

                new Vertebral { Ma = 24,Ten = "S1",Subluxation=false,MidDegeneration=false,ModerateDegeneration=false,SevereDegeneration=false,DegenerativeStenosis=false,Innervation="Hip bones, buttocks.",Possible="Sacroiliac conditions, spinal curvatures."}};
            return listDiscAndJoint;
        }
    }
    public class GioiTinh
    {
        // The default constructor has no parameters. The default constructor  
        // is invoked in the processing of object initializers.  
        // You can test this by changing the access modifier from public to  
        // private. The declarations in Main that use object initializers will  
        // fail. 
        public GioiTinh() { }

        // The following constructor has parameters for two of the three  
        // properties.  
        public GioiTinh(bool ma, string ten)
        {
            ma = Ma;
            ten = Ten;
        }

        // Properties. 
        public bool Ma { get; set; }
        public string Ten { get; set; }

        //public override string ToString()
        //{
        //    return FirstName + "  " + ID;
        //}
    }
    public class Thang
    {
        // The default constructor has no parameters. The default constructor  
        // is invoked in the processing of object initializers.  
        // You can test this by changing the access modifier from public to  
        // private. The declarations in Main that use object initializers will  
        // fail. 
        public Thang() { }

        // The following constructor has parameters for two of the three  
        // properties.  
        public Thang(int thang, string ten)
        {
            thang = So;
            ten = Ten;
        }

        // Properties. 
        public int So { get; set; }
        public string Ten { get; set; }

        //public override string ToString()
        //{
        //    return FirstName + "  " + ID;
        //}
    }
    public class ThaiDoKhachHang
    {
        // The default constructor has no parameters. The default constructor  
        // is invoked in the processing of object initializers.  
        // You can test this by changing the access modifier from public to  
        // private. The declarations in Main that use object initializers will  
        // fail. 
        public ThaiDoKhachHang() { }

        // The following constructor has parameters for two of the three  
        // properties.  
        public ThaiDoKhachHang(int ma, string ten)
        {
            ma = Ma;
            ten = Ten;
        }

        // Properties. 
        public int Ma { get; set; }
        public string Ten { get; set; }

        //public override string ToString()
        //{
        //    return FirstName + "  " + ID;
        //}
    }
    public class LyDoGoi
    {
        // The default constructor has no parameters. The default constructor  
        // is invoked in the processing of object initializers.  
        // You can test this by changing the access modifier from public to  
        // private. The declarations in Main that use object initializers will  
        // fail. 
        public LyDoGoi() { }

        // The following constructor has parameters for two of the three  
        // properties.  
        public LyDoGoi(int ma, string ten)
        {
            ma = Ma;
            ten = Ten;
        }

        // Properties. 
        public int Ma { get; set; }
        public string Ten { get; set; }

        //public override string ToString()
        //{
        //    return FirstName + "  " + ID;
        //}
    }
    public class BaoCaoSinhNhat
    {
        // The default constructor has no parameters. The default constructor  
        // is invoked in the processing of object initializers.  
        // You can test this by changing the access modifier from public to  
        // private. The declarations in Main that use object initializers will  
        // fail. 
        //public Thang() { }

        //// The following constructor has parameters for two of the three  
        //// properties.  
        //public Thang(int thang, string ten)
        //{
        //    thang = So;
        //    ten = Ten;
        //}

        //// Properties. 
        //public int So { get; set; }
        //public string Ten { get; set; }

        //public override string ToString()
        //{
        //    return FirstName + "  " + ID;
        //}
    }
    //Việt hóa
    public class VietNamEditorsLocalizer : Localizer
    {
        public override string Language { get { return "Vietnam"; } }
        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {


                // ...

                case StringId.XtraMessageBoxAbortButtonText: return "Cảnh báo";//////
                case StringId.XtraMessageBoxCancelButtonText: return "Quay lại";
                case StringId.XtraMessageBoxIgnoreButtonText: return "Bỏ qua";
                case StringId.XtraMessageBoxNoButtonText: return "Không";
                case StringId.XtraMessageBoxOkButtonText: return "Đồng ý";
                case StringId.XtraMessageBoxRetryButtonText: return "Thử lại";
                case StringId.XtraMessageBoxYesButtonText: return "Đồng ý";

                // ...
            }
            return base.GetLocalizedString(id);
        }
    }
    public class VietnamGridLocalizer : GridLocalizer
    {

        public override string Language { get { return "Vietnam"; } }
        public override string GetLocalizedString(GridStringId id)
        {
            string result = string.Empty;
            switch (id)
            {
                case GridStringId.MenuColumnSortAscending: return "Sắp xếp tăng";
                case GridStringId.MenuColumnSortDescending: return "Sắp xếp giảm";
                case GridStringId.MenuColumnClearSorting: return "Không sắp xếp";
                case GridStringId.MenuColumnGroup: return "Nhóm cột";

                // ..... dịch thêm cho đầy đủ

                default:
                    result = base.GetLocalizedString(id);
                    break;
            }
            return result;
        }
    }

    public class Complaint
    {
        // The default constructor has no parameters. The default constructor  
        // is invoked in the processing of object initializers.  
        // You can test this by changing the access modifier from public to  
        // private. The declarations in Main that use object initializers will  
        // fail. 
        public Complaint() { }

        // The following constructor has parameters for two of the three  
        // properties.  
        public Complaint(int ma, string ten,bool select)
        {
            ma = Ma;
            ten = Ten;
            select = Select;
        }

        // Properties. 
        public int Ma { get; set; }
        public string Ten { get; set; }
        public bool Select { get; set; }

        //public override string ToString()
        //{
        //    return FirstName + "  " + ID;
        //}
    }

    public class MRIImage
    {
        // The default constructor has no parameters. The default constructor  
        // is invoked in the processing of object initializers.  
        // You can test this by changing the access modifier from public to  
        // private. The declarations in Main that use object initializers will  
        // fail. 
        public MRIImage() { }

        // The following constructor has parameters for two of the three  
        // properties.  
        public MRIImage(int ma, string ten,bool select)
        {
            ma = Ma;
            ten = Ten;
            select = Select;
        }

        // Properties. 
        public int Ma { get; set; }
        public string Ten { get; set; }
        public bool Select { get; set; }

        //public override string ToString()
        //{
        //    return FirstName + "  " + ID;
        //}
    }

    public class DiscAndJoint
    {
        // The default constructor has no parameters. The default constructor  
        // is invoked in the processing of object initializers.  
        // You can test this by changing the access modifier from public to  
        // private. The declarations in Main that use object initializers will  
        // fail. 
        public DiscAndJoint() { }

        // The following constructor has parameters for two of the three  
        // properties.  
        public DiscAndJoint(int ma, string ten, bool degenerated, bool bulging, bool herniated, bool spondylo, bool stenois, bool facetSynrome)
        {
            ma = Ma;
            ten = Ten;
            degenerated = Degenerated;
            bulging = Bulging;
            herniated = Herniated;
            spondylo = Spondylo;
            stenois = Stenois;
            facetSynrome = FacetSynrome;
        }

        // Properties. 
        public int Ma { get; set; }
        public string Ten { get; set; }
        public bool Degenerated { get; set; }
        public bool Bulging { get; set; }
        public bool Herniated { get; set; }
        public bool Spondylo { get; set; }
        public bool Stenois { get; set; }
        public bool FacetSynrome { get; set; }

    }

    public class Vertebral
    {
        // The default constructor has no parameters. The default constructor  
        // is invoked in the processing of object initializers.  
        // You can test this by changing the access modifier from public to  
        // private. The declarations in Main that use object initializers will  
        // fail. 
        public Vertebral() { }

        // The following constructor has parameters for two of the three  
        // properties.  
        public Vertebral(int ma, string ten, bool subluxation, bool midDegeneration, bool moderateDegeneration, bool severeDegeneration, bool degenerativeStenosis, string innervation, string possible)
        {
            ma = Ma;
            ten = Ten;
            subluxation = Subluxation;
            midDegeneration = MidDegeneration;
            moderateDegeneration = ModerateDegeneration;
            severeDegeneration = SevereDegeneration;
            degenerativeStenosis = DegenerativeStenosis;
            innervation = Innervation;
            possible = Possible;
        }

        // Properties. 
        public int Ma { get; set; }
        public string Ten { get; set; }
        public bool Subluxation { get; set; }
        public bool MidDegeneration { get; set; }
        public bool ModerateDegeneration { get; set; }
        public bool SevereDegeneration { get; set; }
        public bool DegenerativeStenosis { get; set; }
        public string Innervation { get; set; }
        public string Possible { get; set; }

    }
    //public class VietnameEditorsLocalizer : Localizer
    //{
    //    public override string Language { get { return "Vietnam"; } }
    //    public override string GetLocalizedString(StringId id)
    //    {
    //        string result = string.Empty;
    //        switch (id)
    //        {
    //            case StringId.CalcError: return "Lỗi phép tính";
    //            case StringId.CaptionError: return "Lỗi";
    //            case StringId.CheckChecked: return "Đánh dấu chọn";
    //            case StringId.CheckIndeterminate: return "CheckIndeterminate";
    //            case StringId.CheckUnchecked: return "Không đánh dấu chọn";

    //             ..... dịch thêm cho đầy đủ

    //            default:
    //                result = base.GetLocalizedString(id);
    //                break;
    //        }
    //        return result;
    //    }
    //}
    //Việt hóa
}

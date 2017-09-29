using System;
using System.IO;

namespace polygon
{
    class MainClass
    {
        public static int polyArea(int[] Xc, int[] Yc, int numPoints){//Shoelace formula implementation.
			int j = numPoints - 1;  
            int area = 0;
			for (int i = 0; i < numPoints; i++)
			{
				int tempArea = (Xc[j] + Xc[i]) * (Yc[j] - Yc[i]);
				area = area + tempArea;
				j = i; 
			}
            if (area < 0) area = area * -1; // if order of points is opposite 
			return area / 2;
        }

        public static bool isClosed(string[] content){//Checking if initial point and end point are the same.
            int len = content.Length - 1;
            if (Convert.ToInt32(content[0]) == Convert.ToInt32(content[len - 2])
               && Convert.ToInt32(content[1]) == Convert.ToInt32(content[len - 1]))
                return true;
            else
                return false;
        }
        public static void Main(string[] args)
        {
            
            string fileName = "test.txt";
            string con = File.ReadAllText(fileName);

            Char[] delims = { ',', '\n' };
            string[] content = con.Split(delims);

            int len = content.Length-1;
            int[] X = new int[len/2], Y = new int[len / 2];
            int index = 0;
            for (int i = 0; i < len; i+=4){
                content[i] = content[i].Trim();
                int.TryParse(content[i], out X[index]);
                int.TryParse(content[i+1], out Y[index]);
                index++;
            }
            if(len>=12){//minimum 3 Sides | 12/4 = 3
                
                if( isClosed(content) ){
                    Console.WriteLine("Closed Polygon");
					int area = polyArea(X, Y, len / 4);
                    Console.WriteLine("Area is ->" +area);

                }else{
                    Console.WriteLine("Not Closed Polygon");
                }
            }else{
                Console.WriteLine("Not a Polygon");

            }

        }
    }
}

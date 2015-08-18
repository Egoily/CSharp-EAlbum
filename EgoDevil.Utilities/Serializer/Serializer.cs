using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace EgoDevil.Utilities.Serializer
{
    public class Serializer
    {

        static public void Serialize(string FileName,object obj)
        {

            FileStream fs = new FileStream(FileName, FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, obj);
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }


        static public object Deserialize(string FileName)
        {
            if (!File.Exists(FileName))
            {
                return null;
            }
            object obj = null;


            FileStream fs = new FileStream(FileName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                obj = (object)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
              MessageBox.Show("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            return obj;

        }


       


    }
}

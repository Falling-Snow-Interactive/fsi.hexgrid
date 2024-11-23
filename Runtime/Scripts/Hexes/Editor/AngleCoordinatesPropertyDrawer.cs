using UnityEditor;
using UnityEngine.UIElements;

namespace Fsi.HexGrid.Hexes.Editor
{
    [CustomPropertyDrawer(typeof(AngleCoordinates))]
    public class AngleCoordinatesPropertyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new VisualElement
                                 {
                                     style =
                                     {
                                         flexDirection = FlexDirection.Row,
                                         flexGrow = 0,
                                         flexShrink = 1,
                                     }
                                 };

            IntegerField qField = new IntegerField("q")
                                   {
                                       isReadOnly = true,
                                       style =
                                       {
                                           flexGrow = 1, 
                                           flexShrink = 1
                                       },
                                       labelElement =
                                       {
                                           style =
                                           {
                                               minWidth = 10f,
                                           }
                                       },
                                   };
            
            IntegerField rField = new IntegerField("r")
                                  {
                                      isReadOnly = true,
                                      style =
                                      {
                                          flexGrow = 1, 
                                          flexShrink = 1
                                      },
                                      labelElement =
                                      {
                                          style =
                                          {
                                              minWidth = 10f,
                                          }
                                      }
                                  };
            IntegerField sField = new IntegerField("s")
                                  {
                                      isReadOnly = true,
                                      style =
                                      {
                                          flexGrow = 1, 
                                          flexShrink = 1
                                      },
                                      labelElement =
                                      {
                                          style =
                                          {
                                              minWidth = 10f,
                                          }
                                      }
                                  };
            
            root.Add(qField);
            root.Add(rField);
            root.Add(sField);

            return root;
        }
    }
}
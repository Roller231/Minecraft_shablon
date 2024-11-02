using UnityEditor;
using FirstPersonMobileTools;

[CustomEditor(typeof(JoystickMobile))]
public class JoystickEditorFirst : Editor {

    JoystickMobile.JoystickMode joystickMode;

    public override void OnInspectorGUI () {

        serializedObject.Update();

        JoystickMobile joystick = (JoystickMobile)target;
        EditorGUILayout.LabelField("Joystick Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("m_JoystickMode"));
        
        if (joystick.m_JoystickMode != JoystickMobile.JoystickMode.Fixed)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_JoystickTouchArea"));
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("m_HandleRectTransform"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("m_HandleBaseRectTransform"));

        if (joystickMode != joystick.m_JoystickMode)
        {
            joystickMode = joystick.m_JoystickMode;
            joystick.OnChangeSettings();
        }

        serializedObject.ApplyModifiedProperties();
        
    }
    
}
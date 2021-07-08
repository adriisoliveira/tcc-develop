import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import { Register } from '../screens/Register'
import { SignIn } from '../screens/SignIn';
import { Login } from '../screens/Login';
import { theme } from '../components/global/styles/theme';

const { Navigator, Screen } = createStackNavigator();

export function AppRoutes() {
  return (
    <Navigator
      headerMode="none"
      screenOptions={{
        cardStyle: {
          backgroundColor: theme.colors.secondary
        }
      }}
    >
      <Screen
        name="SignIn"
        component={SignIn}
      />

      <Screen
        name="Login"
        component={Login}
      />

      <Screen
        name="Register"
        component={Register}
      />
    </Navigator>
  )
}
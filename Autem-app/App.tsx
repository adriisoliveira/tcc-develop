import React from 'react';
import { StatusBar } from 'expo-status-bar';
import { useFonts } from "expo-font";
import {
  Montserrat_400Regular
  , Montserrat_500Medium
  , Montserrat_700Bold
} from "@expo-google-fonts/montserrat";
import AppLoading from "expo-app-loading";
import { StyleSheet, Text, View } from 'react-native';
import { Background } from './src/components/Background';
import { Routes } from './src/routes';

export default function App() {

  const [fontsLoaded] = useFonts({
    Montserrat_400Regular,
    Montserrat_500Medium,
    Montserrat_700Bold,
  })

  if (!fontsLoaded) {
    return <AppLoading />
  }

  return (
    <Background>
      <StatusBar
        backgroundColor="transparent"
        translucent
      />
      <Routes />
    </Background>
  );
}

import React, { useRef, useState } from "react";
import {
  View,
  Text,
  DrawerLayoutAndroid
} from "react-native";
import { Background } from "../../components/Background";
import { styles } from "./styles";
import { useNavigation } from "@react-navigation/native";
import { theme } from "../../components/global/styles/theme";
import { ButtonCreateAc } from "../../components/Button";
import { Menu } from "../../components/Menu";
import { NavigationContainer } from '@react-navigation/native'
import { createDrawerNavigator } from '@react-navigation/drawer';


export function Home() {
  const navigation = useNavigation();
  const { heading } = theme.colors;
  const Drawer = createDrawerNavigator();

  function handleLogin() {
    navigation.navigate('Login');
  }


  return (
    <Background>

      <View style={styles.container}>
        <View>
        </View>

        <View style={styles.reports}>

          <View style={styles.bloco1}></View>

          <View style={styles.bloco2}></View>

          <View style={styles.bloco3}></View>

          <View style={styles.bloco4}></View>
        </View>
      </View>
    </Background>
  );
}
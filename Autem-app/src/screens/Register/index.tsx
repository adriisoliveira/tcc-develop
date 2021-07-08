import React from "react";
import {
  View,
  Image,
  Text,
  TextInput
} from "react-native";
import { Background } from "../../components/Background";
import { styles } from "./styles";
import Logo_Autem from "../../assets/logoAutem.png";
import {
  Button,
  ButtonCreateAc,
  ButtonEnter,
  ButtonGoogle,
  ButtonICloud,
  ButtonFacebook
} from "../../components/Button"
import { useNavigation } from "@react-navigation/native";

export function Register() {
  const navigation = useNavigation();

  function handleLogin() {
    navigation.navigate('Login');
  }

  return (
    <Background>
      <View style={styles.container}>

        <View style={styles.createAccount}>
          <Text style={styles.text}>Login</Text>
          <ButtonCreateAc
            onPress={handleLogin}
          />
        </View>

        <View></View>

        <View></View>

        <View></View>

      </View>
    </Background>

  );
}
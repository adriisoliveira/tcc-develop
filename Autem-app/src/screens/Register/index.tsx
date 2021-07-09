import React from "react";
import {
  View,
  Image,
  Text,
  Platform,
  TextInput,
  Keyboard,
  KeyboardAvoidingView,
  TouchableWithoutFeedback
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
import { theme } from "../../components/global/styles/theme";

export function Register() {
  const navigation = useNavigation();
  const { heading } = theme.colors;

  function handleLogin() {
    navigation.navigate('Login');
  }

  return (
    <Background>
      <TouchableWithoutFeedback onPress={Keyboard.dismiss}>
        <View style={styles.container}>

          <View style={styles.createAccount}>
            <Text style={styles.text}>Login</Text>
            <ButtonCreateAc
              onPress={handleLogin}
            />
          </View>

          <View style={styles.inputs}>
            <TextInput
              style={styles.textInput}
              placeholder="Nome"
              placeholderTextColor={heading}
            />
            <TextInput
              style={styles.textInput}
              placeholder="Email"
              placeholderTextColor={heading}
            />
            <TextInput
              style={styles.textInput}
              placeholder="Senha"
              placeholderTextColor={heading}
            />
            <TextInput
              style={styles.textInput}
              placeholder="Confirmar Senha"
              placeholderTextColor={heading}
            />
          </View>

          <View style={styles.buttonEnter}>
            <ButtonEnter
              title="Entrar"
              onPress={handleLogin}
            />
          </View>

          <View style={styles.buttonSocialMidia}>
            <ButtonGoogle />
            <ButtonFacebook />
            <ButtonICloud />
          </View>
        </View>
      </TouchableWithoutFeedback>
    </Background>

  );
}
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
import { theme } from "../../components/global/styles/theme";

export function Login() {
  const navigation = useNavigation();
  const { heading } = theme.colors;

  function handleSignIn() {
    navigation.navigate('SignIn');
  }

  function handleRegister() {
    navigation.navigate('Register');
  }

  function handleHome() {
    navigation.navigate('Home');
  }

  return (
    <Background>
      <View style={styles.container}>
        <View style={styles.createAccount}>
          <Text style={styles.text}>Criar Conta</Text>
          <ButtonCreateAc
            onPress={handleRegister}
          />
        </View>

        <View style={styles.inputs}>
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
        </View>

        <View style={styles.buttonsLogin}>
          <View style={styles.password}>
            <Button
              title="Esqueci a Senha"
              onPress={handleSignIn} />
          </View>

          <View style={styles.buttonEnter}>
            <ButtonEnter
              title="Entrar"
              onPress={handleHome}
            />
          </View>
        </View>

        <View style={styles.buttonSocialMidia}>
          <ButtonGoogle />
          <ButtonFacebook />
          <ButtonICloud />
        </View>

        <View></View>

      </View>
    </Background>

  );

}
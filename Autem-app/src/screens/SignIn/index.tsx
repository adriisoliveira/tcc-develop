import React, { ReactNode } from "react";
import {
  View,
  Image
} from "react-native";
import { styles } from "./styles";
import { Button } from "../../components/Button";
import { theme } from "../../components/global/styles/theme";
import { Background } from "../../components/Background";
import { useNavigation } from '@react-navigation/native';
import Logo_Autem from '../../assets/logoAutem.png';



export function SignIn() {
  const navigation = useNavigation();

  function handleSignIn() {
    navigation.navigate('Login');
  }

  return (
    <Background>
      <View style={styles.container}>
        <View style={styles.containerLogo}>
          <Image
            source={Logo_Autem}
            style={styles.image}
            resizeMode="stretch"
          />
        </View>
        <Button
          title="Entrar"
          onPress={handleSignIn}
        />
      </View>
    </Background>

  )
}
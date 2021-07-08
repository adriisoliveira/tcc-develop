import React from 'react';
import {
  View,
  Image,
  Text
} from 'react-native';
import { RectButton, RectButtonProps } from 'react-native-gesture-handler';
import { MaterialCommunityIcons } from '@expo/vector-icons';

import Apple from '../../assets/Apple.png';
import Google from '../../assets/Google.png';
import Facebook from "../../assets/Facebook.png";
import CreateAc from "../../assets/CreateAccount.png"

import { styles } from './styles';
import { theme } from '../global/styles/theme';

type Props = RectButtonProps & {
  title?: string;
}

export function Button({ title, ...rest }: Props) {
  return (
    <RectButton
      style={styles.container}
      {...rest}
    >
      <MaterialCommunityIcons
        color={theme.colors.heading}
        size={24}
      />
      <Text style={styles.title}>
        {title}
      </Text>
    </RectButton>
  )
}

export function ButtonCreateAc({ ...rest }: Props) {
  return (
    <RectButton
      style={styles.buttonAc}
      {...rest}
    >
      <View style={styles.buttonAc}>
        <Image source={CreateAc} style={styles.buttonAc} />
      </View>

    </RectButton>
  );
}

export function ButtonEnter({ title, ...rest }: Props) {
  return (
    <RectButton
      style={styles.buttonEnter}
    >
      <Text style={styles.textEnter}>
        {title}
      </Text>
    </RectButton>
  );
}

export function ButtonGoogle() {
  return (
    <RectButton
      style={styles.buttonGg}
    >
      <View style={styles.buttonGg}>
        <Image source={Google} style={styles.buttonGg} />
      </View>
    </RectButton>
  );
}

export function ButtonFacebook() {
  return (
    <RectButton
      style={styles.buttonFc}
    >
      <View style={styles.buttonFc}>
        <Image source={Facebook} style={styles.buttonFc} />
      </View>
    </RectButton>
  );
}

export function ButtonICloud() {
  return (
    <RectButton
      style={styles.buttonIc}
    >
      <View style={styles.buttonIc}>
        <Image source={Apple} style={styles.buttonIc} />
      </View>
    </RectButton>
  );
}

